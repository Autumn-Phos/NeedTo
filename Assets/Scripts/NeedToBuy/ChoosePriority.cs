using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class ChoosePriority : MonoBehaviour {
    private int _selectedPriorityNumber;

    [SerializeField] private int _defaultPriority;
    [SerializeField] private GameObject[] _priorityHighlight;

    private void Start() {
        UpdateSelectedPriority(_defaultPriority);
    }

    public void UpdateSelectedPriority(int pressedButton) {
        for (int i = 0; i < _priorityHighlight.Length; i++) {
            if (i != pressedButton) {
                _priorityHighlight[i].GetComponent<CanvasGroup>().alpha = 0f;
            } else {
                _selectedPriorityNumber = i;
                _priorityHighlight[i].GetComponent<CanvasGroup>().alpha = 1f;
            }
        }
    }

    public int GetSelectedPriorityNumber() {
        return _selectedPriorityNumber;
    }
}