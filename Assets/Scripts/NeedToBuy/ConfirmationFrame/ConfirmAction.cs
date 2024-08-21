using UnityEngine.Events;
using UnityEngine;

public class ConfirmAction : MonoBehaviour {
    [SerializeField] private GameObject _confirmationFrameContainer;
    private UnityEvent _scriptForConfirm;
    
    public void StartConfirmationOfAction(UnityEvent scriptForConfirm) {
        OpenConfirmationFrame();
        AssignScriptForConfirm(scriptForConfirm);
    }

    public void Confirm() {
        _scriptForConfirm.Invoke();
        CloseConfirmationFrame();
    }

    public void UnConfirm() {
        CloseConfirmationFrame();
    }

    private void AssignScriptForConfirm(UnityEvent scriptsForConfirm) {
        _scriptForConfirm = scriptsForConfirm;
    }

    private void OpenConfirmationFrame() {
        _scriptForConfirm = null;
        _confirmationFrameContainer.SetActive(true);
    }

    private void CloseConfirmationFrame() {
        _scriptForConfirm = null;
        _confirmationFrameContainer.SetActive(false);
    }
}
