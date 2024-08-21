using UnityEngine.Localization.Settings;
using UnityEngine;

public class LoadActiveLocale : MonoBehaviour {
    private void Awake() {
        int localeIndex = PlayerPrefs.GetInt("SelectedLocaleIndex");
        print("ActiveLocale: " + LocalizationSettings.AvailableLocales.Locales[localeIndex]);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeIndex];
    }
}
