using Microsoft.Win32;
using System;
using System.Globalization;
using System.Management;

namespace EmuSak_Revive.SystemInfo
{
    public static class OperatingSystem
    {
        private static readonly ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

        #region Public Properties

        public static string OSName => GetProperty("Caption");
        public static string OSBuild => GetBuildNumber();
        public static string OSArchitecture => GetProperty("OSArchitecture");
        public static string OSServicePack => GetProperty("CSDVersion");
        public static string OSSystemDirectory => GetProperty("SystemDirectory");
        public static string OSCountryCode => GetProperty("CountryCode");

        #endregion Public Properties

        private static string GetProperty(string propertyName)
        {
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject[propertyName] != null)
                {
                    return $"Operating System {propertyName}={managementObject[propertyName].ToString()}\n";
                }
            }
            return propertyName + "=Undefined\n";
        }

        private static string GetBuildNumber()
        {
            return "Operating System Build=" +
                $"{Environment.OSVersion.Version.Major}." +
                $"{Environment.OSVersion.Version.Minor}." +
                $"{Environment.OSVersion.Version.Build}" + "\n";
        }
    }
}