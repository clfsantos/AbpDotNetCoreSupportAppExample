using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Tecsmart.Suporte.Localization
{
    public static class SuporteLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SuporteConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SuporteLocalizationConfigurer).GetAssembly(),
                        "Tecsmart.Suporte.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
