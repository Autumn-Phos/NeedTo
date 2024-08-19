using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScrollRectSwipeDetector : MonoBehaviour {
    [SerializeField] private float _responseTime;
    [SerializeField] private Coroutine _timerCoroutine;
    [SerializeField] private FillCart _fillCart;
    [SerializeField] private GameObject _loadingSpinnerImage;
    
    private ScrollRect _scrollRect;

    private void Start() {
        _scrollRect = gameObject.GetComponent<ScrollRect>();
    }

    public void OnScrollRectValueChanged(Vector2 value) {
            if (_scrollRect.content.anchoredPosition.y < -100f && _scrollRect.velocity.y < 0) {
                if (_timerCoroutine == null) {
                    _timerCoroutine = StartCoroutine(TimerToUpdateCartFills());
                    _loadingSpinnerImage.SetActive(true);
                }
            }
            else {
                if (_timerCoroutine != null) {
                    StopCoroutine(_timerCoroutine);
                    _timerCoroutine = null;
                    _loadingSpinnerImage.SetActive(false);
                }
            }
    }

    private IEnumerator TimerToUpdateCartFills() {
        yield return new WaitForSeconds(_responseTime);

        Debug.Log("Detected swipe, started update cart fills");
        _fillCart.UpateCartFills();
    }
}