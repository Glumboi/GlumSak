using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Animation;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.CrashReporter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        private string[] startArgs = new string[] { };

        private string[] crashWords = new string[]
        {
            "Something went wrong in GlumSak, here is the Error:",
            "Seems like an exception occured:",
            "Houston, we have a problem:",
            "Oh no, GlumSak crashed! Please report the following to the Dev:"
        };

        public MainWindow(string[] args)
        {
            InitializeComponent();

            startArgs = args;
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string rndInd = crashWords[random.Next(0, crashWords.Length)];

            CrashWords_TextBlock.Text = rndInd;

            foreach (var item in startArgs)
            {
                CrashReport_TextBox.Text += item;
            }
        }

        private void CopyToClipBord_Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(CrashReport_TextBox.Text);
        }

        private void SaveErrorToFile_Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.FileName = "GlumSakErrorReport_" + DateTime.Now.ToString().Replace(':', '-') + ".txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, CrashReport_TextBox.Text);
            }
        }
    }
}