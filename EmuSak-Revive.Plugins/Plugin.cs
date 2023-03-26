using EmuSak_Revive.ConfigIni.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
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

        private IniParser iniParser;

        public Plugin(string locationOfPlugin, string iniLocation)
        {
            DllPath = locationOfPlugin;
            IniPath = iniLocation;

            iniParser = new IniParser(IniPath);

            LoadPluginName();
            LoadPluginIcon();
            LoadEntryPoint();
            LoadClass();
            LoadNamespace();
            LoadParams();
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
            IsRunning = false;
            _hookThread.Abort();
        }

        public void ExecutePlugin()
        {
            IsRunning = true;
            try
            {
                _hookThread = new Thread(HookPlugin);
                _hookThread.SetApartmentState(ApartmentState.STA);
                _hookThread.Start();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void HookPlugin()
        {
            string dllFile = DllPath;

            Debug.WriteLine("Loading Plugin: " + dllFile);
            Assembly assembly = Assembly.LoadFile(dllFile);
            Type type = assembly.GetType($"{EntryPointClassNameSpace}.{EntryPointClass}");
            object obj = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(EntryPoint);

            PlugInResult = method.Invoke(obj, new object[] { Parameters });
        }
    }
}