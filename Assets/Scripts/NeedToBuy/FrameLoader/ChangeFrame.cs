using UnityEngine;

public class ChangeFrame : MonoBehaviour {
    private enum SceneLoadingType {
        Standard,
        WithLoadingScripts
    }

    [SerializeField] private GameObject _activeFrame;
    [SerializeField] private SceneLoadingType _sceneLoadingType;

    private Transform _framesContainerTransform => FindObjectOfType<Transform>();

    public void BindActiveFrame(GameObject activeFrame) {
        _activeFrame = activeFrame;
    }

    public void ChangeFrames(GameObject _frame) {
        if (_frame != null) {
            GameObject newFrame = Instantiate(_frame, _activeFrame.transform.parent);

            switch (_sceneLoadingType) {
                case SceneLoadingType.Standard:
                    Debug.Log("Standart load");
                    break;
                case SceneLoadingType.WithLoadingScripts:
                    LoadFrame loadFrame = newFrame.GetComponent<LoadFrame>();
                    if (loadFrame != null) {
                        loadFrame.StartLoadFrame();
                        Debug.Log("Load with scripts");
                    }
                    else {
                        Debug.LogWarning("ERROR: not found \"Start Load Frame\"");
                    }
                    break;
                default:
                    Debug.LogWarning("ERROR: not found \"Scene Loading Type\"");
                    break;
            }

            if (_activeFrame != null) Destroy(_activeFrame);
        }
    }
}