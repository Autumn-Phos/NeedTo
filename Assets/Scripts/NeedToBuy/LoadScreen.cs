using System.Collections;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;

    private static GameObject s_loadScreen;

    private void Awake () {
        s_loadScreen = _loadScreen;
    }

    public static void StartLoadScreen() {
        if (s_loadScreen != null) {
            s_loadScreen.SetActive(true);
        } else {
            Debug.Log("Load screen not found reference in scene");
        }
    }

    public static void CloseLoadScreen() {
        if (s_loadScreen != null) {
            s_loadScreen.SetActive(false);
        } else {
            Debug.Log("Load screen not found reference in scene");
        }  
    }
}