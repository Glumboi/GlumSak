using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.GUI.Generics
{
    internal class VersionSorter
    {
        public static IComparable OrderVersion(string arg)
        {
            //Treat N/A as highest version
            if (arg == "N/A")
                return new Version(Int32.MaxValue, Int32.MaxValue);
            return Version.Parse(arg);
        }
    }
}