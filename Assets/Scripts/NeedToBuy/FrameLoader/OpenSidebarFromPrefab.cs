using UnityEngine;

public class OpenSidebarFromPrefab : MonoBehaviour {
    private CloseOpenSidebar _sidebar;

    private void Start() {
        _sidebar = FindObjectOfType<CloseOpenSidebar>();
    }

    public void OpenSidebar(GameObject activeFrame) {
        if (_sidebar != null) {
            _sidebar.OpenSidebar(activeFrame);
        }
        else {
            Debug.LogWarning("ERROR: not found \"Close Open Sidebar\"");
        }
    }
}
