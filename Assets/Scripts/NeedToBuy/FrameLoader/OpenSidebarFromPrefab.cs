using UnityEngine;

public class OpenSidebarFromPrefab : MonoBehaviour {
    public void OpenSidebar(GameObject activeFrame) {
        CloseOpenSidebar sidebar = FindObjectOfType<CloseOpenSidebar>();
        
        if (sidebar != null) {
            sidebar.OpenSidebar(activeFrame);
        }
        else {
            Debug.LogWarning("ERROR: not found \"Close Open Sidebar\"");
        }
    }
}
