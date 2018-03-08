using System.IO;
using System.Windows.Forms;

namespace PingTheList
{
    public class Config
    {
        private const string ConfigPath = "PingTheList.json";


        public static string Get()
        {
            var filepath = System.IO.Path.Combine(Application.StartupPath, ConfigPath);

            if (File.Exists(filepath))
            {
                var text = File.ReadAllText(filepath);

                return text;
            }

            return string.Empty;
        }

        public static bool Save(string text)
        {
            var filepath = System.IO.Path.Combine(Application.StartupPath, ConfigPath);

            if (!string.IsNullOrEmpty(text))
            {
                File.WriteAllText(filepath, text);

                return true;
            }

            return false;
        }
    }
}
