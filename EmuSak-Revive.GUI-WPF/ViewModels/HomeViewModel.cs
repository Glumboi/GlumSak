using EmuSak_Revive.GUI_WPF.Extensions;
using EmuSak_Revive.Network;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmuSak_Revive.GUI_WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private int _selectedFirmware = 0;

        public int SelectedFirmware
        {
            get => _selectedFirmware;
            set => SetProperty(ref _selectedFirmware, value);
        }

        private List<string> _firmwares = Network.Networking.GetFirmwareVersions();

        public List<string> Firmwares
        {
            get => _firmwares;
            set => SetProperty(ref _firmwares, value);
        }
    }
}