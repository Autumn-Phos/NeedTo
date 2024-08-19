using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace ToastFactory {
    public class ToastMaker : MonoBehaviour {
        [SerializeField] private GameObject toast;
        [SerializeField] private int defaultVisibilityTime;

        private static GameObject s_toast;
        private static float fadeDuration = 0.5f;
        private static int s_defaultVisibilityTime;
        private static Queue<ToastData> s_toastQueue = new Queue<ToastData>();

        private struct ToastData {
            public string message;
            public bool selfClosing;
            public int visibilityTime;
        }

        private void Awake()
        {
            s_toast = toast;
            s_defaultVisibilityTime = defaultVisibilityTime;
        }

        public static void MakeAToast(string toastMessage, bool selfСlosing = true, int visibilityTime = -1) {
            ToastData toastData = new ToastData {
                message = toastMessage,
                selfClosing = selfСlosing,
                visibilityTime = visibilityTime
            };

            s_toastQueue.Enqueue(toastData);
            ShowNextToast();
        }

        private static void ShowNextToast() {
            if (s_toastQueue.Count > 0 && !s_toast.activeInHierarchy) {
                ToastData nextToast = s_toastQueue.Dequeue();
                ChangeToastMessage(nextToast.message);

                s_toast.SetActive(true);
                Debug.Log("Was created toast with message - " + nextToast.message);

                if (nextToast.selfClosing) {
                    if (nextToast.visibilityTime < 0) {
                        nextToast.visibilityTime = s_defaultVisibilityTime;
                    }

                    StartCloseToast(nextToast.visibilityTime);
                }
            }
        }

        private static void ChangeToastMessage(string toastMessage) {
            TextMeshProUGUI toastText = s_toast.GetComponentInChildren<TextMeshProUGUI>(); 
            toastText.text = toastMessage;
        }

        public static void StartCloseToast(int visibilityTime) {
            FindObjectOfType<ToastMaker>().StartCoroutine(CloseToastAutomaticaly(visibilityTime));
        }
        
        private static IEnumerator CloseToastAutomaticaly(int visibilityTime) {
            CanvasGroup canvasGroup = s_toast.GetComponent<CanvasGroup>();
            if (canvasGroup == null) {
                Debug.LogError("Тоаст не имеет компонента CanvasGroup!");
                yield break;
            }

            yield return new WaitForSeconds(visibilityTime);

            float elapsedTime = 0f; 
            while (elapsedTime < fadeDuration) {
                canvasGroup.alpha = 1f - (elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            s_toast.SetActive(false);
            canvasGroup.alpha = 1f;

            ShowNextToast();
        }
    }
}