using System.Collections.Generic;
using System.Globalization;

namespace Grogshot.Localization {
    public class LocalizationDataProvider : ILocalizationDataProvider {
        public LocalizationDataProvider(LocalizationDataStructure dataStructure) {
            AvailableCultures = dataStructure.AvailableCultures;
            DefaultCulture = dataStructure.DefaultCulture;
            Data = new Dictionary<string, IDictionary<string, string>>();
            AddTextData(dataStructure);
        }

        private void AddTextData(LocalizationDataStructure dataStructure) {
            foreach (var textGroup in dataStructure.TextGroups) {
                foreach (var text in textGroup.Texts) {
                    Data.Add(string.Format("{0}_{1}", textGroup.Id, text.Id), text.Text);
                }
            }
        }

        public CultureInfo[] AvailableCultures { get; private set; }

        public CultureInfo DefaultCulture { get; private set; }

        public IDictionary<string, IDictionary<string, string>> Data { get; private set; }
    }
}