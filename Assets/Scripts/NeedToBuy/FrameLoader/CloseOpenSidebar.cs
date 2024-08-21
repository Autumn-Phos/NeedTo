using UnityEngine;

public class CloseOpenSidebar : MonoBehaviour {
    [SerializeField] private ChangeFrame _changeFrame;

    private GameObject _sidebar => gameObject;

    public void OpenSidebar(GameObject activeFrame) {
        _sidebar.SetActive(true);
        _changeFrame.BindActiveFrame(activeFrame);
    }

    public void CloseSidebar() {
        _sidebar.GetComponent<Animator>().SetTrigger("CloseSidebar");
    }

    public void SetActiveSidebar() {
        _sidebar.SetActive(false);
    }
}
