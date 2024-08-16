using UnityEngine;
using TMPro;

public class ShowAppVersion : MonoBehaviour
{
    private string _appVersion => Application.version;

    private void Start()
    {
        print("Application Version: " + _appVersion);
        gameObject.GetComponent<TextMeshProUGUI>().text = "Version: " + _appVersion;
    }
}
