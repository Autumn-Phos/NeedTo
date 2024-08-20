using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CrossOutText : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI[] _productNames;

    public void SwitchCrossOutText() {
        bool toggleIsOn = gameObject.GetComponent<Toggle>().isOn;
        
        foreach(var _productName in _productNames) {
            if (_productName != null) {
                _productName.fontStyle = toggleIsOn ? FontStyles.Strikethrough : FontStyles.Normal;
            }
        }
    }
}
