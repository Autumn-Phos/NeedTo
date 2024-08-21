using System.Collections.Generic;
using System.Collections;
using CutsomRequests;
using UnityEngine;

public class GetProducts : MonoBehaviour {
    [SerializeField] private CreateProductRequest _createProductRequest;
    [SerializeField] private string additionalURL;

    public IEnumerator StartFormirateProductRequest(bool getPurchasedProducts) {
        string purchasedProductsString = getPurchasedProducts ? "1" : "0";
        Dictionary<string, string> getPurchasedProductsForm = new Dictionary<string, string>() {{APIConfig.productIsPurchased_NameOfVariableInDatabase, purchasedProductsString}};

        yield return StartCoroutine(_createProductRequest.SendPostAPIRequest(getPurchasedProductsForm, additionalURL));
    }

    public string GetAPIResponse() {
        return APIRequestSender.GetLatestResponseText();
    }
}