using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleLocalization {
    public enum Language { Eng, Rus }

    public class Localizer {
        public Dictionary<string, Translation> _translations = new Dictionary<string, Translation>();

        public Localizer() { }

        public Localizer(LocalizerData data) {
            foreach (var item in data.localizations) {
                var name = Format(item.Name);
                _translations.Add(name, item);
            }
        }

        private string Format(string text) {
            text = text.Trim();
            text = text.ToUpper();
            text = Regex.Replace(text, @"[\W-[\s]]", "");
            text = Regex.Replace(text, @"[\s]+", " ");
            text = Regex.Replace(text, @"[{_}]+", "_");
            while (text.Contains("  ")) {
                text.Replace("  ", " ");
            }
            return text;
        }

        public string GetTranslate(string text, Language language) {
            var name = Format(text);
            if (_translations.ContainsKey(name)) {
                var translation = _translations[name];
                switch (language) {
                    case Language.Eng:
                        return translation.Eng;
                    case Language.Rus:
                        return translation.Rus;                        
                }
            }
            return text;
        }
    }
}
