using System.Collections.Generic;
using System.Collections;
using CutsomRequests;
using UnityEngine;

public class DeleteProduct : MonoBehaviour {
    [SerializeField] private CreateProductRequest _createProductRequest;
    [SerializeField] private ProductsContainer _productsContainer;
    [SerializeField] private string additionalURL;
    [SerializeField] private FillCart _fillCart;

    public void StartDeleteProduct() {
        StartCoroutine(StartFormirateDeleteProductRequest());
    }

    private IEnumerator StartFormirateDeleteProductRequest() {
        List<string> productsIds = new List<string>();

        foreach(GameObject product in _productsContainer.TakeHighlightedProductsToDelete()) {
            ProductData productData = product.GetComponent<ProductContent>().TakeProductInfo();
            productsIds.Add(productData.productId);
        }
        
        Dictionary<string, string> _productsToDelete = new Dictionary<string, string>() {{"productId", string.Join(",", productsIds)}};

        yield return StartCoroutine(_createProductRequest.SendPostAPIRequest(_productsToDelete, additionalURL));

        _fillCart.UpateCartFills();
    }
}