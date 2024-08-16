using System.Collections.Generic;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;

namespace CutsomRequests {
    public static class APIRequestSender {
        private static string _latestResponseText;
        private static bool _latestResponseSuccessful;

        public static IEnumerator APIRequest(string baseURL, string additionalURL, WWWForm form = null) {
            string URL = baseURL + additionalURL;
            
            UnityWebRequest webRequest;

            if (form != null) {
                webRequest = UnityWebRequest.Post(URL, form);
            } else {
                webRequest = UnityWebRequest.Get(URL);
            }
            
            using (webRequest) {
                yield return webRequest.SendWebRequest();

                _latestResponseText = webRequest.downloadHandler.text;

                if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
                    _latestResponseSuccessful = false;
                    Debug.Log(webRequest.error);
                    Debug.Log("ERROR Handler - " + webRequest.error);
                } else {
                    _latestResponseSuccessful = true;
                    Debug.Log("INFO Handler - " + _latestResponseText);
                }
            }
        }

        public static string GetLatestResponseText() {
            return _latestResponseText;
        }

        public static bool GetLatestResponseSuccessful() {
            return _latestResponseSuccessful;
        }
    }
    
    public static class FormConfigurator {
        public static WWWForm CreateForm(Dictionary<string, string> data) {
            WWWForm form = new WWWForm();

            foreach (KeyValuePair<string, string> entry in data) {
                form.AddField(entry.Key, entry.Value);
            }

            return form;
        }
    }
}