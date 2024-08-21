using UnityEngine;

public class CloseOpenSidebar : MonoBehaviour {
    [SerializeField] private ChangeFrame _changeFrame;
    [SerializeField] private GameObject _sidebarFrame;

    public void OpenSidebar(GameObject activeFrame) {
        _sidebarFrame.SetActive(true);
        _changeFrame.BindActiveFrame(activeFrame);
    }

    public void CloseSidebar() {
        _sidebarFrame.GetComponent<Animator>().SetTrigger("CloseSidebar");
    }
}
