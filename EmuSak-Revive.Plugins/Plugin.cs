using EmuSak_Revive.ConfigIni.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace EmuSak_Revive.Plugins
{
    public class Plugin
    {
        private Thread _hookThread;

        private bool _isRunning;

        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (value != _isRunning)
                {
                    _isRunning = value;
                }
            }
        }

        private IntPtr _mainWindowHandle;

        public IntPtr MainWindowHandle
        {
            get => _mainWindowHandle;
            set
            {
                if (value != _mainWindowHandle)
                {
                    _mainWindowHandle = value;
                }
            }
        }

        private string _pluginName;

        public string PluginName
        {
            get => _pluginName;
            set
            {
                if (value != _pluginName)
                {
                    _pluginName = value;
                }
            }
        }

        private string _pluginIcon;

        public string PluginIcon
        {
            get => _pluginIcon;
            set
            {
                if (value != _pluginIcon)
                {
                    _pluginIcon = value;
                }
            }
        }

        private string _dllPath;

        public string DllPath
        {
            get => _dllPath;
            set
            {
                if (value != _dllPath)
                {
                    _dllPath = value;
                }
            }
        }

        private string _iniPath;

        public string IniPath
        {
            get => _iniPath;
            set
            {
                if (value != _iniPath)
                {
                    _iniPath = value;
                }
            }
        }

        private string _entryPoint;

        public string EntryPoint
        {
            get => _entryPoint;
            set
            {
                if (value != _entryPoint)
                {
                    _entryPoint = value;
                }
            }
        }

        private string _entryPointClass;

        public string EntryPointClass
        {
            get => _entryPointClass;
            set
            {
                if (value != _entryPointClass)
                {
                    _entryPointClass = value;
                }
            }
        }

        private string _entryPointClassNameSpace;

        public string EntryPointClassNameSpace
        {
            get => _entryPointClassNameSpace;
            set
            {
                if (value != _entryPointClassNameSpace)
                {
                    _entryPointClassNameSpace = value;
                }
            }
        }

        private object[] _parameters;

        public object[] Parameters
        {
            get => _parameters;
            set
            {
                if (value != _parameters)
                {
                    _parameters = value;
                }
            }
        }

        private object _plugInResult;

        public object PlugInResult
        {
            get => _plugInResult;
            set
            {
                if (value != _plugInResult)
                {
                    _plugInResult = value;
                }
            }
        }

        private List<string> _possiblePahts = new List<string>();

        private IniParser iniParser;

        public Plugin(IntPtr mainWindowHandle, List<string> possiblePaths, string iniLocation)
        {
            _possiblePahts = possiblePaths;
            MainWindowHandle = mainWindowHandle;
            IniPath = iniLocation;

            iniParser = new IniParser(IniPath);

            LoadPluginName();
            LoadEntryPoint();
            LoadClass();
            LoadNamespace();
            LoadParams();

            GetRightDll();

            LoadPluginIcon();
        }

        private void LoadPluginName()
        {
            PluginName = iniParser.GetSetting("GlumSakPlugin", "PluginName");
        }

        private void LoadPluginIcon()
        {
            PluginIcon = Path.GetDirectoryName(DllPath) + "\\" + iniParser.GetSetting("GlumSakPlugin", "PluginIcon");
        }

        private void LoadNamespace()
        {
            EntryPointClassNameSpace = iniParser.GetSetting("GlumSakPlugin", "Namespace");
        }

        private void LoadEntryPoint()
        {
            EntryPoint = iniParser.GetSetting("GlumSakPlugin", "Entrypoint");
        }

        private void LoadClass()
        {
            EntryPointClass = iniParser.GetSetting("GlumSakPlugin", "Class");
        }

        private void LoadParams()
        {
            string[] paramsOfIni = iniParser.GetSetting("GlumSakPlugin", "Params").Split(',');

            List<object> objects = new List<object>();

            foreach (object parameter in paramsOfIni)
            {
                objects.Add(parameter);
            }

            Parameters = objects.ToArray();
        }

        public void StopPlugin()
        {
            _hookThread.Abort();
            IsRunning = false;
        }

        public void ExecutePlugin()
        {
            if (IsRunning)
            {
                StopPlugin();
                ExecutePlugin();
                return;
            }

            IsRunning = true;

            try
            {
                _hookThread = new Thread(HookPlugin);
                _hookThread.Name = PluginName + " {Thread}";
                _hookThread.SetApartmentState(ApartmentState.STA);
                _hookThread.Start();
            }
            catch (Exception)
            {
                return;
            }
        }

        private Type _entrypointType;

        private void GetRightDll()
        {
            foreach (var item in _possiblePahts)
            {
                Assembly assembly = Assembly.LoadFile(item);
                Type type = assembly.GetType($"{EntryPointClassNameSpace}.{EntryPointClass}");
                if (type != null)
                {
                    DllPath = item;
                    _entrypointType = type;
                }
            }
        }

        private void HookPlugin()
        {
            Type type = _entrypointType;
            object obj = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(EntryPoint);

            PlugInResult = method.Invoke(obj, new object[] { MainWindowHandle, Parameters });
        }
    }
}