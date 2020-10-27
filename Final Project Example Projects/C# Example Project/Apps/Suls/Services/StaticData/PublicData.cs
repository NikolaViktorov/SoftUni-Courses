using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Suls.Services.StaticData
{
    public class PublicData
    {
        public static string apiKey => "RGAPI-950b44be-2d0b-407d-a462-529e506ef5af";

        public static string ddVerision => GetLatestVersion();

        private static string GetLatestVersion()
        {
            string url = "https://ddragon.leagueoflegends.com/api/versions.json";
            var req = (HttpWebRequest)WebRequest.Create(url);
            var latestVersion = string.Empty;

            req.Method = "GET";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            {
                if (res.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + res.StatusCode);
                }

                using (Stream resStream = res.GetResponseStream())
                {
                    if (resStream != null)
                    {
                        using (StreamReader reader = new StreamReader(resStream))
                        {
                            string[] result = reader.ReadToEnd().Split(new char[] { '[', ']', '\\', '\"', '{', '}', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

                            latestVersion = result[0];
                        }
                    }
                }
            }

            return latestVersion;
        }
    }
}
