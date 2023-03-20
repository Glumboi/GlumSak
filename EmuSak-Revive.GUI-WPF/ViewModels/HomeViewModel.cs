namespace EmuSak_Revive.GUI_WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private string _homeTabString = "Home";

        public string HomeTabString
        {
            get => _homeTabString;
            set
            {
                if (value != _homeTabString)
                {
                    SetProperty(ref _homeTabString, value);
                }
            }
        }

        private string _downloadFirmwareString = "Download Firmware";

        public string DownloadFirmwareString
        {
            get => _downloadFirmwareString;
            set
            {
                if (value != _downloadFirmwareString)
                {
                    SetProperty(ref _downloadFirmwareString, value);
                }
            }
        }

        private string _downloadKeysString = "Download Keys";

        public string DownloadKeysString
        {
            get => _downloadKeysString;
            set
            {
                if (value != _downloadKeysString)
                {
                    SetProperty(ref _downloadKeysString, value);
                }
            }
        }

        private string _clearFilterString = "Clear Filter";

        public string ClearFilterString
        {
            get => _clearFilterString;
            set
            {
                if (value != _clearFilterString)
                {
                    SetProperty(ref _clearFilterString, value);
                }
            }
        }

        private string _filterPlaceHolderString = "Enter a Filter";

        public string FilterPlaceHolderString
        {
            get => _filterPlaceHolderString;
            set
            {
                if (value != _filterPlaceHolderString)
                {
                    SetProperty(ref _filterPlaceHolderString, value);
                }
            }
        }

        private string _cancelDownloadString = "Cancel Download";

        public string CancelDownloadString
        {
            get => _cancelDownloadString;
            set
            {
                if (value != _cancelDownloadString)
                {
                    SetProperty(ref _cancelDownloadString, value);
                }
            }
        }
    }
}