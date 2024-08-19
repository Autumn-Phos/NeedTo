using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ChangeFrame : MonoBehaviour
{
    private enum SceneLoadingType {
        Standard,
        WithLoadingScripts
    }

    [SerializeField] private SceneLoadingType _sceneLoadingType;
    [SerializeField] private GameObject _firstFrame;
    [SerializeField] private GameObject _secondFrame;
    [SerializeField] private GameObject[] _auxiliaryFrames;

    public void ChangeFramesFromFirstToSecond() {
        if (_secondFrame != null) _secondFrame.SetActive(true);

        switch (_sceneLoadingType) {
            case SceneLoadingType.Standard:
                Debug.Log("Обычная загрузка");
                break;
            case SceneLoadingType.WithLoadingScripts:
                _secondFrame.GetComponent<LoadFrame>().StartLoadFrame();
                Debug.Log("Загрузка со скриптами");
                break;
            default:
                Debug.LogWarning("Неизвестный тип загрузки!");
                break;
        }
        

        CloseSubFrame();
        if (_firstFrame != null) _firstFrame.SetActive(false);
    }

    private void CloseSubFrame () {
        foreach(var auxiliaryFrame in _auxiliaryFrames) {
            if(auxiliaryFrame != null) auxiliaryFrame.SetActive(false);
        }
    }
}