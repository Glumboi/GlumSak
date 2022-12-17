using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.GUI.Generics
{
    internal static class VersionSorter
    {
        public static IComparable OrderVersion(string arg)
        {
            //Treat N/A as highest version
            return arg == "N/A" ? new Version(Int32.MaxValue, Int32.MaxValue) : Version.Parse(arg);
        }
    }
}