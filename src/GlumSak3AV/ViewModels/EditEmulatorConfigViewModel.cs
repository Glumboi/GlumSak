using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using GlumSak3AV.Switch;
using GlumSak3AV.Views;

namespace GlumSak3AV.ViewModels;

public class EditEmulatorConfigViewModel : ViewModelBase
{
    private Emulator _emulator;

    public Emulator Emulator
    {
        get => _emulator;
        set
        {
            if (value != _emulator)
            {
                _emulator = value;
                JsonDummy = value.JsonData;
            }
        }
    }

    private EmuJsonDummy _jsonDummy;

    public EmuJsonDummy JsonDummy
    {
        get => _jsonDummy;
        set
        {
            _jsonDummy = value;
            EmuConfigName = value.name;
            EmuConfigLinuxRootPath = value.linuxRootPath;
            EmuConfigWindowsRootPath = value.windowsRootPath;
            UsesFoldersAsCache = value.isGamesCachedAsFolder;
            EmuGamesPath = value.gamePath;
            EmuKeysPath = value.keysPath;
            EmuFirmwarePath = value.firmwarePath;
            JsonFileName = string.IsNullOrWhiteSpace(Emulator.JsonFile) ? "Filename" : Emulator.JsonFile;
            EmuGameShaderPath = value.shaderCacheRootpath;
            EmulatorPaste = value.emulatorPaste;
            SupportsShaderInstallation = value.supportsShaderInstallation;
        }
    }

    private string _jsonFileName;

    public string JsonFileName
    {
        get => _jsonFileName;
        set => SetProperty(ref _jsonFileName, value);
    }

    private string _emuConfigName;

    public string EmuConfigName
    {
        get => _emuConfigName;
        set => SetProperty(ref _emuConfigName, value);
    }

    private string _emuConfigLinuxRootPath;

    public string EmuConfigLinuxRootPath
    {
        get => _emuConfigLinuxRootPath;
        set => SetProperty(ref _emuConfigLinuxRootPath, value);
    }

    private string _emuConfigWindowsRootPath;

    public string EmuConfigWindowsRootPath
    {
        get => _emuConfigWindowsRootPath;
        set => SetProperty(ref _emuConfigWindowsRootPath, value);
    }

    private string _emuGamesPath;

    public string EmuGamesPath
    {
        get => _emuGamesPath;
        set => SetProperty(ref _emuGamesPath, value);
    }


    private string _emuFirmwarePath;

    public string EmuFirmwarePath
    {
        get => _emuFirmwarePath;
        set => SetProperty(ref _emuFirmwarePath, value);
    }

    private string _emuKeysPath;

    public string EmuKeysPath
    {
        get => _emuKeysPath;
        set => SetProperty(ref _emuKeysPath, value);
    }

    private string _emuGameShaderPath;

    public string EmuGameShaderPath
    {
        get => _emuGameShaderPath;
        set => SetProperty(ref _emuGameShaderPath, value);
    }


    private bool _usesFoldersAsCache;

    public bool UsesFoldersAsCache
    {
        get => _usesFoldersAsCache;
        set => SetProperty(ref _usesFoldersAsCache, value);
    }

    private bool _supportsShaderInstallation;

    public bool SupportsShaderInstallation
    {
        get => _supportsShaderInstallation;
        set => SetProperty(ref _supportsShaderInstallation, value);
    }


    private string _emulatorPaste;

    public string EmulatorPaste
    {
        get => _emulatorPaste;
        set => SetProperty(ref _emulatorPaste, value);
    }

    public ICommand AcceptCommand { get; internal set; }

    void CreateAcceptCommand()
    {
        AcceptCommand = new RelayCommand(Accept);
    }

    void Accept()
    {
        JsonDummy.name = EmuConfigName;
        JsonDummy.linuxRootPath = EmuConfigLinuxRootPath;
        JsonDummy.windowsRootPath = EmuConfigWindowsRootPath;
        JsonDummy.isGamesCachedAsFolder = UsesFoldersAsCache;
        JsonDummy.gamePath = EmuGamesPath;
        JsonDummy.keysPath = EmuKeysPath;
        JsonDummy.firmwarePath = EmuFirmwarePath;
        JsonDummy.shaderCacheRootpath = EmuGameShaderPath;
        JsonDummy.emulatorPaste = EmulatorPaste;
        JsonDummy.supportsShaderInstallation = SupportsShaderInstallation;
        JsonOperations.WriteNewConfig(JsonDummy, JsonFileName);

        EditEmulatorConfigWindow._editEmuConfigWindow.Close();
    }

    public ICommand ResetCommand { get; internal set; }

    void CreateResetCommand()
    {
        ResetCommand = new RelayCommand(Reset);
    }

    void Reset()
    {
        EmuConfigName = JsonDummy.name;
        EmuConfigLinuxRootPath = JsonDummy.linuxRootPath;
        EmuConfigWindowsRootPath = JsonDummy.windowsRootPath;
        UsesFoldersAsCache = JsonDummy.isGamesCachedAsFolder;
        EmuGamesPath = JsonDummy.gamePath;
        EmuKeysPath = JsonDummy.keysPath;
        EmuFirmwarePath = JsonDummy.firmwarePath;
        EmuGameShaderPath = JsonDummy.shaderCacheRootpath;
        EmulatorPaste = JsonDummy.emulatorPaste;
        SupportsShaderInstallation = JsonDummy.supportsShaderInstallation;
    }

    public ICommand CancelCommand { get; internal set; }

    void CreateCancelCommand()
    {
        CancelCommand = new RelayCommand(Cancel);
    }

    void Cancel()
    {
        EditEmulatorConfigWindow._editEmuConfigWindow.Close();
    }

    public ICommand AutoLoadCommand { get; internal set; }

    void CreateAutoLoadCommand()
    {
        AutoLoadCommand = new RelayCommand(AutoLoadExtraPaths);
    }

    void AutoLoadExtraPaths()
    {
        if (UsesFoldersAsCache)
        {
            EmuGamesPath = "";
        }
    }

    public EditEmulatorConfigViewModel()
    {
        CreateAutoLoadCommand();
        CreateAcceptCommand();
        CreateResetCommand();
        CreateCancelCommand();
    }
}