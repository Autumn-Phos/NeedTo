using System.Collections;
using CutsomRequests;
using UnityEngine;

public class GetProducts : MonoBehaviour {
    [SerializeField] private CreateProductRequest _createProductRequest;
    [SerializeField] private FillCart _fillCart;
    [SerializeField] private string additionalURL;

    public IEnumerator StartFormirateProductRequest() {
        yield return StartCoroutine(_createProductRequest.SendGetAPIRequest(additionalURL));
    }

    public string GetAPIResponse() {
        return APIRequestSender.GetLatestResponseText();
    }
}