using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace GlumSak3AV.ViewModels;

public class CloudSaveViewModel : ViewModelBase
{
    public ICommand LoginWithGoogleCommand { get; internal set; }

    public CloudSaveViewModel()
    {
        CreateLoginWithGoogleCommand();
    }

    void CreateLoginWithGoogleCommand()
    {
        LoginWithGoogleCommand = new RelayCommand(LoginWithGoogle);
    }

    void LoginWithGoogle()
    {
        Console.WriteLine("Result from rust code :", CsBindgen.NativeMethods.my_add(10, 10));
    }
}