using System.Collections.Generic;
using System.Collections;
using CutsomRequests;
using ToastFactory;
using UnityEngine;

public class CreateProductRequest : MonoBehaviour {
    public IEnumerator SendGetAPIRequest(string additionalURL) {
        LoadScreen.StartLoadScreen();

        yield return StartCoroutine(APIRequestSender.APIRequest(APIConfig.URL, additionalURL));

        if (APIRequestSender.GetLatestResponseSuccessful()) {
            ToastMaker.MakeAToast("Successfully!");
        } else {
            ToastMaker.MakeAToast("Something went wrong!", false);
        }

        LoadScreen.CloseLoadScreen();
    }

    public IEnumerator SendPostAPIRequest(Dictionary<string, string> productData, string additionalURL) {
        LoadScreen.StartLoadScreen();

        yield return StartCoroutine(APIRequestSender.APIRequest(APIConfig.URL, additionalURL, FormConfigurator.CreateForm(productData)));

        if (APIRequestSender.GetLatestResponseSuccessful()) {
            ToastMaker.MakeAToast("Successfully!");
        } else {
            ToastMaker.MakeAToast("Something went wrong!", false);
        }

        LoadScreen.CloseLoadScreen();
    }
}