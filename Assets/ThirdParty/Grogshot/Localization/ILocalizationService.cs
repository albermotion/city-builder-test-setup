using System.Collections.Generic;
using System.Globalization;

namespace Grogshot.Localization {
    public interface ILocalizationService {
        string this[string reference] {get;}
        string this[string reference, CultureInfo cultureInfo] { get; }

        IList<CultureInfo> AvailableCultures { get; }
        CultureInfo DefaultCulture { get; }
        CultureInfo CurrentCulture { get; set; }

        event CultureInfoChange OnCultureChanged;
    }

    public delegate void CultureInfoChange(CultureInfo prevInfo, CultureInfo currentCulture);
}