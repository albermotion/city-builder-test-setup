using System.Collections.Generic;
using System.Globalization;

namespace Grogshot.Localization {
    public interface ILocalizationDataProvider { 
        CultureInfo[] AvailableCultures { get; }
        CultureInfo DefaultCulture { get; }
        IDictionary<string, IDictionary<string, string>> Data { get; }
    }
}