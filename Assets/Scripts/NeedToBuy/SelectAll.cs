using UnityEngine.UI;
using UnityEngine;

public class SelectAll : MonoBehaviour {
    public void SelectAllToggle(Toggle selectAllToggle) {
        bool selectAllToggleIsOn = selectAllToggle.isOn;
        var toggles = gameObject.GetComponentsInChildren<Toggle>();

        if (toggles != null) {
            foreach(var toggle in toggles) {
                toggle.isOn = selectAllToggleIsOn;
            }
        }
    }
}
