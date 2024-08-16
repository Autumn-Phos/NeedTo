using UnityEngine.UI;
using UnityEngine;

public class ChooseOneOfTheOptions : MonoBehaviour {
    private int _selectedOptionNumber;
    [SerializeField] private int _defaultOption;
    [SerializeField] private GameObject[] _optionHighlight = new GameObject[3];

    public void UpdateSelectedOptions(int pressedButton) {
        for (int i = 0; i < _optionHighlight.Length; i++) {
            if (i != pressedButton) {
                _optionHighlight[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
            } else {
                _selectedOptionNumber = i;
                _optionHighlight[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 1f, 0.2f);
            }
        }
    }

    public void SetDefaultOption() {
        UpdateSelectedOptions(_defaultOption);
    }

    public int GetSelectedOptionNumber() {
        return _selectedOptionNumber;
    }
}