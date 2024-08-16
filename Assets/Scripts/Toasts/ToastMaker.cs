using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ToastMaker : MonoBehaviour {
    [SerializeField] private GameObject toast;
    [SerializeField] private int defaultVisibilityTime;

    private static GameObject s_toast;
    private static int s_defaultVisibilityTime;

    private void Awake()
    {
        s_toast = toast;
        s_defaultVisibilityTime = defaultVisibilityTime;
    }

    public static void MakeAToast(string toastMessage, bool selfСlosing = true, int visibilityTime = -1) {
        ChangeToastMessage(toastMessage);

        s_toast.SetActive(true);
        Debug.Log("Was created toast with message - " + toastMessage);

        if (selfСlosing){
            if (visibilityTime < 0) {
                visibilityTime = s_defaultVisibilityTime;
            }

            StartCloseToast(visibilityTime);
        }
    }

    public static void StartCloseToast(int visibilityTime) {
        FindObjectOfType<ToastMaker>().StartCoroutine(CloseToastAutomaticaly(visibilityTime));
    }

    private static void ChangeToastMessage(string toastMessage) {
        TextMeshProUGUI toastText = s_toast.GetComponentInChildren<TextMeshProUGUI>(); 
        toastText.text = toastMessage;
    }
    
    private static IEnumerator CloseToastAutomaticaly(int visibilityTime) {
        Animator animator = s_toast.GetComponent<Animator>();

        yield return new WaitForSeconds(visibilityTime);

        animator.SetTrigger("DisappereToast");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animator.GetCurrentAnimatorStateInfo(0).IsName("DisappereToast"));
    }
}