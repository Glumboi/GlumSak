using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmuSak_Revive.SystemInfo
{
    public static class GpuInfo
    {
        #region Gpu Properties

        public static string GetGpuName => GetGpuProperty("Name");
        public static string GetGpuDrivers => GetGpuProperty("InstalledDisplayDrivers");
        public static string GetGpuDriverVersion => GetGpuProperty("DriverVersion");

        #endregion Gpu Properties

        private static string GetGpuProperty(string propertyName)
        {
            ManagementObjectSearcher gpuObj = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject managementObject in gpuObj.Get())
            {
                if (managementObject[propertyName] != null)
                {
                    return $"GPU {propertyName}={managementObject[propertyName].ToString()}\n";
                }
            }
            return propertyName + "=Undefined\n";
        }
    }

    public static class CpuInfo
    {
        #region Cpu Properties

        public static string GetCpuName => GetCpuProperty("Name");
        public static string GetCpuID => GetCpuProperty("DeviceID");
        public static string GetCpuManufacturer => GetCpuProperty("Manufacturer");
        public static string GetCpuClockSpeed => GetCpuProperty("CurrentClockSpeed");
        public static string GetCpuCaption => GetCpuProperty("Caption");
        public static string GetCpuCores => GetCpuProperty("NumberOfCores");
        public static string GetCpuLogicalCores => GetCpuProperty("NumberOfLogicalProcessors");

        #endregion Cpu Properties

        private static string GetCpuProperty(string propertyName)
        {
            ManagementObjectSearcher cpuObj = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject managementObject in cpuObj.Get())
            {
                if (managementObject[propertyName] != null)
                {
                    return $"CPU {propertyName}={managementObject[propertyName].ToString()}\n";
                }
            }
            return propertyName + "=Undefined\n";
        }
    }
}