using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using GlumSak3AV.Switch;
using GlumSak3AV.ViewModels;

namespace GlumSak3AV.Views;

public partial class EditEmulatorConfigWindow : Window
{
    private EmuJsonDummy _jsonDummy;

    private bool _windowDragging = false;
    private PointerPoint _originalPoint;
    public static Window _editEmuConfigWindow;

    public EditEmulatorConfigWindow()
    {
        InitializeComponent();
        
        _editEmuConfigWindow = this;
        EditEmulatorConfigViewModel dT = new EditEmulatorConfigViewModel();
        this.DataContext = dT;
        dT.JsonDummy = new EmuJsonDummy
        {
            name = "Your config name here",
            firmwarePath = "Firmware path here",
            gamePath = "Game path here",
            linuxRootPath = "Linux root path here",
            windowsRootPath = "Windows root path here",
            isGamesCachedAsFolder = false,
            keysPath = "Keys path here"
        };
    }
    
    public EditEmulatorConfigWindow(EmuJsonDummy jsonOfCurrentEmu)
    {
        InitializeComponent();
        _editEmuConfigWindow = this;
        EditEmulatorConfigViewModel dT = new EditEmulatorConfigViewModel();
        this.DataContext = dT;
        dT.JsonDummy = jsonOfCurrentEmu;
    }

    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (!_windowDragging) return;

        PointerPoint currentPoint = e.GetCurrentPoint(this);
        Position = new PixelPoint(Position.X + (int)(currentPoint.Position.X - _originalPoint.Position.X),
            Position.Y + (int)(currentPoint.Position.Y - _originalPoint.Position.Y));
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (WindowState == WindowState.Maximized || WindowState == WindowState.FullScreen) return;

        _windowDragging = true;
        _originalPoint = e.GetCurrentPoint(this);
    }

    private void InputElement_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        _windowDragging = false;
    }
}