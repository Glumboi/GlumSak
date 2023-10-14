using System.ComponentModel;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GlumSak3AV.ViewModels;

namespace GlumSak3AV.Views;

public partial class SplashScreen : Window
{
    private bool _windowDragging = false;
    private PointerPoint _originalPoint;

    public SplashScreen()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.DoWork += WorkerOnDoWork;
        worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
        worker.RunWorkerAsync();
    }

    private void WorkerOnRunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
    {
        MainWindow mw = new MainWindow()
        {
            DataContext = new MainViewModel()
        };
        mw.Show();
        Close();
    }

    private void WorkerOnDoWork(object? sender, DoWorkEventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(80);
        }
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