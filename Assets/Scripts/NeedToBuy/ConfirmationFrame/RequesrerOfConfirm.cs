using UnityEngine.Events;
using UnityEngine;

public class RequesrerOfConfirm : MonoBehaviour {
    [SerializeField] private UnityEvent _scriptForConfirm;

    public void StartRequestOfConfirm() { 
        FindObjectOfType<ConfirmAction>().StartConfirmationOfAction(_scriptForConfirm);
    }
}
