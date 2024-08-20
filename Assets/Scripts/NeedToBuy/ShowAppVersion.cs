using UnityEngine;
using TMPro;

public class ShowAppVersion : MonoBehaviour
{
    private string _appVersion => Application.version;

    private void Start() {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Version: " + _appVersion;
    }
}
