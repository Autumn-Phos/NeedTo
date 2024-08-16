using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFrame : MonoBehaviour
{
    [SerializeField] private GameObject _firstFrame;
    [SerializeField] private GameObject _secondFrame;

    [SerializeField] private GameObject[] _auxiliaryFrames;

    public void ChangeFramesFromFirstToSecond() {
        if (_secondFrame != null) _secondFrame.SetActive(true);

        CloseSubFrame();
        if (_firstFrame != null) _firstFrame.SetActive(false);
    }

    public void CloseSubFrame() {
        foreach(var auxiliaryFrame in _auxiliaryFrames) {
            if(auxiliaryFrame != null) auxiliaryFrame.SetActive(false);
        }
    }
}