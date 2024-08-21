using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using UnityEngine;

public class ChooseLanguage : MonoBehaviour
{
    [SerializeField] private int _selectedLocaleIndex;
    [SerializeField] private GameObject[] _languageHighlight;

    private void Start() {
        UpdateSelectedLanguage(PlayerPrefs.GetInt("SelectedLocaleIndex"));
    }

    public void UpdateSelectedLanguage(int pressedButton) {
        for (int i = 0; i < _languageHighlight.Length; i++) {
            if (i != pressedButton) {
                _languageHighlight[i].GetComponent<CanvasGroup>().alpha = 0f;
            } else {
                _selectedLocaleIndex = i;
                _languageHighlight[i].GetComponent<CanvasGroup>().alpha = 1f;

                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_selectedLocaleIndex];
                SaveSelectedLocaleIndex();
            }
        }
    }

    private void SaveSelectedLocaleIndex() {
        PlayerPrefs.SetInt("SelectedLocaleIndex", _selectedLocaleIndex);
        PlayerPrefs.Save();
    }
}
