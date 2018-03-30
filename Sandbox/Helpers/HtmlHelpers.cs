using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Sandbox.HtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        private static string ImageRoot = "Content/images/";

        public static MvcHtmlString InlineSvg(this HtmlHelper htmlHelper, string src)
        {
            string htmlOutput = "";
            string path = ImageRoot + src + ".svg";

            try
            {
                // Open the text file using a stream reader.
                string absoPath = AppDomain.CurrentDomain.BaseDirectory + path;
                using (StreamReader sr = new StreamReader(absoPath))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    htmlOutput = line;
                }
            }
            catch (Exception e)
            {
                htmlOutput = ($"<img src=\"/{path}\" />");
                // TODO: Error Logging
            }

            return MvcHtmlString.Create(htmlOutput);
        }
    }
}