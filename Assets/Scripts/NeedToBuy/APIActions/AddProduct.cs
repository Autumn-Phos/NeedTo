using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AddProduct : MonoBehaviour {
    [SerializeField] private ProductDataCollector _productDataCollector;
    [SerializeField] private CreateProductRequest _createProductRequest;
    [SerializeField] private ChangeFrame _changeFrame;
    [SerializeField] private string additionalURL;
    [SerializeField] private FillCart _fillCart;

    private Dictionary<string, string> _productData = new Dictionary<string, string>();

    public void StartAddProduct() {
        StartCoroutine(StartFormirateProductRequest());
    }

    private IEnumerator StartFormirateProductRequest() {
        _productData = _productDataCollector.CollectProductInfo();
        
        foreach (KeyValuePair<string, string> entry in _productData) {
            print(entry.Key + " " + entry.Value);
        }

        yield return StartCoroutine(_createProductRequest.SendPostAPIRequest(_productData, additionalURL));

        ClearDictionary();
        _fillCart.UpateCartFills();
    }

    private void ClearDictionary() {
        _productData.Clear();
    }
}
