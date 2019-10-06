using System.Collections.Generic;
using System.Globalization;

namespace Grogshot.Localization {
    public class LocalizationDataStructure {
        public CultureInfo[] AvailableCultures { get; set; }
        public CultureInfo DefaultCulture { get; set; }
        public TextGroup[] TextGroups { get; set; }
    }

    public class TextGroup { 
        public string Id { get; set; }
        public TextData[] Texts { get; set; }
    }

    public class TextData {
        public string Id { get; set; }
        public IDictionary<string, string> Text { get; set; }
    }
}
