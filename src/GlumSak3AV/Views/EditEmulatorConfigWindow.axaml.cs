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

    public EditEmulatorConfigWindow(EmuJsonDummy jsonOfCurrentEmu)
    {
        InitializeComponent();
        this.DataContext = new EditEmulatorConfigViewModel();
        _jsonDummy = jsonOfCurrentEmu;
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