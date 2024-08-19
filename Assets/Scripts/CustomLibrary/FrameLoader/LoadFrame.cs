using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LoadFrame : MonoBehaviour {
    [SerializeField] private UnityEvent _loadScripts;

    public void StartLoadFrame() {
        if (_loadScripts != null) {
            _loadScripts.Invoke(); 
        }
    }
}
