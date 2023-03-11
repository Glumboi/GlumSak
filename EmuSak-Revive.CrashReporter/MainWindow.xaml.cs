using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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
            "Ah damn, I'm such a bad dev. Here's the Error:",
            "Damn, did you see that? Just like that what the hell? Anyways here's the error:",
            "Nah but like why did he do that like that like cmon. Seems like this is the error:",
            "Let's say that this was your fault ok? I don't know but that looks like the error:",
            "Is this your first time using a software? Or is the dev just plain stupid? Looks like an error:"
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