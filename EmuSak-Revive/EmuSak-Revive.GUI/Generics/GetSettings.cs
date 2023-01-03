namespace EmuSak_Revive.GUI.Generics
{
    public static class GetSettings
    {
        public static bool GetCheckForUpdates()
        {
            return Properties.Settings.Default.CheckForUpdatesOnStartup;
        }
    }
}