using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.ConfigIni.Core
{
    /// <summary>
    /// I tweaked some code by myself here to make it work online, source:
    /// https://stackoverflow.com/questions/217902/reading-writing-an-ini-file
    /// </summary>

    public class IniParser
    {
        private Hashtable keyPairs = new Hashtable();
        private String iniFilePath;

        private struct SectionPair
        {
            public String Section;
            public String Key;
        }

        /// <summary>
        /// Opens the INI file at the given path and enumerates the values in the IniParser.
        /// </summary>
        /// <param name="iniPath">Full path to INI file.</param>

        public IniParser(string iniPath)
        {
            iniFilePath = iniPath;
            keyPairs = new Hashtable();
            StringBuilder currentRootBuilder = new StringBuilder();

            try
            {
                using (StreamReader reader = new StreamReader(iniPath))
                {
                    string strLine;
                    while ((strLine = reader.ReadLine()) != null)
                    {
                        strLine = strLine.Trim();
                        if (strLine != string.Empty)
                        {
                            if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                            {
                                currentRootBuilder.Clear();
                                currentRootBuilder.Append(strLine.Substring(1, strLine.Length - 2));
                            }
                            else
                            {
                                string[] keyPair = strLine.Split(new char[] { '=' }, 2);

                                SectionPair sectionPair;
                                sectionPair.Section = currentRootBuilder.Length > 0 ? currentRootBuilder.ToString() : "ROOT";
                                sectionPair.Key = keyPair[0];
                                string value = keyPair.Length > 1 ? keyPair[1] : null;

                                keyPairs[sectionPair] = value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns the value for the given section, key pair.
        /// </summary>
        /// <param name="sectionName">Section name.</param>
        /// <param name="settingName">Key name.</param>
        public String GetSetting(String sectionName, String settingName)
        {
            SectionPair sectionPair;
            sectionPair.Section = sectionName;
            sectionPair.Key = settingName;

            return (String)keyPairs[sectionPair];
        }

        /// <summary>
        /// Enumerates all lines for given section.
        /// </summary>
        /// <param name="sectionName">Section to enum.</param>
        public String[] EnumSection(String sectionName)
        {
            ArrayList tmpArray = new ArrayList();

            foreach (SectionPair pair in keyPairs.Keys)
            {
                if (pair.Section == sectionName)
                    tmpArray.Add(pair.Key);
            }

            return (String[])tmpArray.ToArray(typeof(String));
        }

        /// <summary>
        /// Adds or replaces a setting to the table to be saved.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        /// <param name="settingValue">Value of key.</param>
        public void AddSetting(String sectionName, String settingName, String settingValue)
        {
            SectionPair sectionPair;
            sectionPair.Section = sectionName;
            sectionPair.Key = settingName;

            if (keyPairs.ContainsKey(sectionPair))
                keyPairs.Remove(sectionPair);

            keyPairs.Add(sectionPair, settingValue);
        }

        /// <summary>
        /// Adds or replaces a setting to the table to be saved with a null value.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        public void AddSetting(String sectionName, String settingName)
        {
            AddSetting(sectionName, settingName, null);
        }

        /// <summary>
        /// Remove a setting.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        public void DeleteSetting(String sectionName, String settingName)
        {
            SectionPair sectionPair;
            sectionPair.Section = sectionName;
            sectionPair.Key = settingName;

            if (keyPairs.ContainsKey(sectionPair))
                keyPairs.Remove(sectionPair);
        }

        /// <summary>
        /// Save settings to new file.
        /// </summary>
        /// <param name="newFilePath">New file path.</param>
        public void SaveSettings(String newFilePath)
        {
            ArrayList sections = new ArrayList();
            String tmpValue = "";
            String strToSave = "";

            foreach (SectionPair sectionPair in keyPairs.Keys)
            {
                if (!sections.Contains(sectionPair.Section))
                    sections.Add(sectionPair.Section);
            }

            foreach (String section in sections)
            {
                strToSave += ("[" + section + "]\r\n");

                foreach (SectionPair sectionPair in keyPairs.Keys)
                {
                    if (sectionPair.Section == section)
                    {
                        tmpValue = (String)keyPairs[sectionPair];

                        if (tmpValue != null)
                            tmpValue = "=" + tmpValue;

                        strToSave += (sectionPair.Key + tmpValue + "\r\n");
                    }
                }

                strToSave += "\r\n";
            }

            try
            {
                TextWriter tw = new StreamWriter(newFilePath);
                tw.Write(strToSave);
                tw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save settings back to ini file.
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(iniFilePath);
        }
    }
}