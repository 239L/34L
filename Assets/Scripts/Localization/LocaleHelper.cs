using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NearYouNameSpace.Localization
{
    public static class LocaleHelper
    {

        public static string getLang()
        {
            SystemLanguage lang = Application.systemLanguage;
            switch (lang)
            {
                case SystemLanguage.Russian: return LocaleApp.RU;
                case SystemLanguage.Spanish: return LocaleApp.ES;
                case SystemLanguage.Danish: return LocaleApp.DA;
                case SystemLanguage.English:
                default: return LocaleApp.EN;
            }
        }
    }
}