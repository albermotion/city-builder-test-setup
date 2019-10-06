using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Grogshot.Localization {
    public class LocalizationService : ILocalizationService {
        private readonly IDictionary<string, IDictionary<string, string>> texts;
        private CultureInfo currentCulture;
        public event CultureInfoChange OnCultureChanged;

        public LocalizationService(ILocalizationDataProvider dataProvider) {
            AvailableCultures = dataProvider.AvailableCultures;
            DefaultCulture = dataProvider.DefaultCulture;
            CurrentCulture = DefaultCulture;
            texts = dataProvider.Data;

            OnCultureChanged?.Invoke(null, CurrentCulture);
        }

        public string this[string reference] => this[reference, CurrentCulture];

        public string this[string reference, CultureInfo cultureInfo] {
            get {
                if (texts.ContainsKey(reference)) {
                    return texts[reference][cultureInfo.Name];
                }

                throw new KeyNotFoundException(string.Format("Missing reference {0}", reference));
            }
        }

        public IList<CultureInfo> AvailableCultures { get; private set; }
        public CultureInfo DefaultCulture { get; private set; }
        public CultureInfo CurrentCulture {
            get { return currentCulture; }
            set {
                CultureInfo cultureData = AvailableCultures.FirstOrDefault(c => c.Name.Equals(value.Name));

                if (cultureData != null) {
                    CultureInfo previous = currentCulture;

                    currentCulture = cultureData;

                    OnCultureChanged?.Invoke(previous, currentCulture);
                } else {
                    throw new CultureNotFoundException(string.Format("Culture '{0}' is not an available culture", value.Name));
                }
            }
        }
    }
}