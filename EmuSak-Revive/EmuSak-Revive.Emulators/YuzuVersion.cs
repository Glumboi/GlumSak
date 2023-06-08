using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.Emulators
{
    internal struct YuzuVersion
    {
        public string DirectDownloadURL
        {
            get;
            private set;
        }

        public string VersionString
        {
            get;
            private set;
        }

        public YuzuVersion(string directDownloadURL, string versionString)
        {
            DirectDownloadURL = directDownloadURL;
            VersionString = versionString;
        }
    }
}