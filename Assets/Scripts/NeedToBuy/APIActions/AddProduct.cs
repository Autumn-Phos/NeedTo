using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AddProduct : MonoBehaviour {
    private CreateProductRequest _createProductRequest => FindObjectOfType<CreateProductRequest>();

    [SerializeField] private ProductDataCollector _productDataCollector;
    [SerializeField] private GameObject _cartFrameContent;
    [SerializeField] private string additionalURL;

    public void StartAddProduct() {
        StartCoroutine(StartFormirateProductRequest());
    }

    private IEnumerator StartFormirateProductRequest() {
        Dictionary<string, string> _productData = _productDataCollector.CollectProductInfo();
        
        foreach (KeyValuePair<string, string> entry in _productData) {
            print(entry.Key + " " + entry.Value);
        }

        yield return StartCoroutine(_createProductRequest.SendPostAPIRequest(_productData, additionalURL));
        
        gameObject.GetComponent<ChangeFrame>().ChangeFrames(_cartFrameContent);
    }
}
