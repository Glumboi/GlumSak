using EmuSak_Revive.ConfigIni.Core;
using Octokit;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace EmuSak_Revive.Network
{
    public static class VersionControl
    {
        public static Version InstalledVersion { get; private set; }
        public static Version NewVersion { get; private set; }
        public static string NewVersionString { get; private set; }
        public static string Changelog { get; private set; }

        private static IniParser iniParser = new IniParser("./updaterConfig.ini");

        public static async Task<bool> CheckGitHubNewerVersion(Assembly refAsm)
        {
            string workspaceName = iniParser.GetSetting("config", "author"); //"Glumboi";
            string repositoryName = iniParser.GetSetting("config", "repo");//"GlumSak";

            //Get all releases from GitHub
            //Source: https://octokitnet.readthedocs.io/en/latest/getting-started/
            var client = new GitHubClient(new ProductHeaderValue("Glumboi"));
            // var releases = await client.Repository.Release.GetAll(workspaceName, repositoryName);
            var release = await client.Repository.Release.GetLatest(workspaceName, repositoryName);

            Changelog = "" +
                "<style>\r\n    " +
                "html *\r\n    " +
                "{\r\n        " +
                    "font-family: Russo One;\r\n    " +
                    "color: White;\r\n" +
                    "font-size: 13px; \r\n" +
                "}\r\n" +
                "</style>" + MarkDown.MarkDownToHtml.GetHtmlOfMarkDown(release.Body);

            //Setup the versions
            var latestGitHubVersion = new Version(release.TagName);

            var Reference = refAsm.GetName();
            var Version = Reference.Version;
            var localVersion = new Version(Version.ToString()); //Replace this with your local version.
            InstalledVersion = localVersion;
            NewVersion = latestGitHubVersion;
            //Only tested with numeric values.

            //Compare the Versions
            //Source: https://stackoverflow.com/questions/7568147/compare-version-numbers-without-using-split-function
            var versionComparison = localVersion.CompareTo(latestGitHubVersion);
            if (versionComparison < 0)
            {
                //The version on GitHub is more up to date than this local release.
                return true;
            }
            else if (versionComparison > 0)
            {
                //This local version is greater than the release version on GitHub.
                return false;
            }
            else
            {
                //This local Version and the Version on GitHub are equal.
                return false;
            }
        }
    }
}