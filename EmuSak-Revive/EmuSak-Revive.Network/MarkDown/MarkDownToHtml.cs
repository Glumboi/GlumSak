using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdig;

namespace EmuSak_Revive.Network.MarkDown
{
    public static class MarkDownToHtml
    {
        /// <summary>
        /// Returns the given markdown as html string
        /// </summary>
        /// <param name="inputMarkDown"></param>
        /// <returns></returns>
        public static string GetHtmlOfMarkDown(string inputMarkDown)
        {
            return Markdown.ToHtml(inputMarkDown);
        }
    }
}