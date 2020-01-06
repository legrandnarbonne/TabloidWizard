
using Tabloid.Classes.Objects.OlObjects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace TabloidWizard.Classes
{
    public static class OlStyleCollection
    {
        public static List<OlStyle> olStyles { get; set; }

        /// <summary>
        /// Save wizard styles to wizstyles.js file
        /// </summary>
        /// <param name="path"></param>
        public static void Save(string path)
        {
            var res = olStyles.ToDictionary(x => x.Name, x => x);

            var result = JsonConvert.SerializeObject(res, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                TypeNameHandling=TypeNameHandling.Auto
            });

            result = $"var wizStyles={result};";
            
            Directory.CreateDirectory(path + "\\Scripts");//create if not exist

            using (var sw = new StreamWriter(path + "\\Scripts\\wizstyles.js"))
                sw.Write(result);
        }
        /// <summary>
        /// Load wizard style from file
        /// </summary>
        /// <param name="path">root project path</param>
        public static void Load(string path)
        {
            string res;
            olStyles = new List<OlStyle>();
            var filePath = path + "\\Scripts\\wizstyles.js";
            var fi = new FileInfo(filePath);

            if (fi.Exists)
            {
                using (var sr = new StreamReader(filePath))
                    res = sr.ReadToEnd();
                if (res.Length > 0)
                    try
                    {
                        var jsonTxt = res.Substring(14, res.Length - 15);
                        // add quote to function value
                        jsonTxt = Regex.Replace(jsonTxt, @"(function\s*\(([,a-z]*)?\)\s*)(\{(.*?)?(\{(.*?)(\{(\{(.*?)\})*\})*\})*\})", delegate (Match match)
                        {
                            string v = match.ToString();
                            v = v.Replace("\"", "\\\"");//escape quote inside function
                            return $"\"{v}\"";
                        }
                        , RegexOptions.Singleline);



                        var tmp = JsonConvert.DeserializeObject<Dictionary<string, OlStyle>>(jsonTxt, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto
                        });

                        foreach (var s in tmp)
                        {
                            s.Value.Name = s.Key;
                            olStyles.Add(s.Value);
                        }
                    }
                    catch(Exception)
                    { }
            }
        }
    }
}
