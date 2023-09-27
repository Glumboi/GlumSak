namespace GlumSak3AV.ViewModels;

public class EditEmulatorConfigViewModel : ViewModelBase
{
    public string _emuConfigName = "Yuzu (Standard)";

    public string EmuConfigName
    {
        get => _emuConfigName;
        set => SetProperty(ref _emuConfigName, value);
    }
}