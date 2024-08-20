using UnityEngine;

public class ChangeFrame : MonoBehaviour {
    private enum SceneLoadingType {
        Standard,
        WithLoadingScripts
    }

    [SerializeField] private GameObject _openFrame;
    [SerializeField] private GameObject _frame;
    [SerializeField] private SceneLoadingType _sceneLoadingType;

    private Transform _framesContainerTransform => FindObjectOfType<Transform>();

    public void ChangeFrames() {
        if (_frame != null) {
            GameObject newFrame = Instantiate(_frame, _openFrame.transform.parent);

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

            if (_openFrame != null) Destroy(_openFrame);
        }
    }
}