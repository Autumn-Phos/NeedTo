using System.Collections.Generic;
using System.Collections;
using CutsomRequests;
using UnityEngine;

public class MarkPurchasedProducts : MonoBehaviour {
    private CreateProductRequest _createProductRequest => FindObjectOfType<CreateProductRequest>();

    [SerializeField] private ProductsContainer _productsContainer;
    [SerializeField] private string _additionalURL;
    [SerializeField] private FillCart _fillCart;

    public void StartMarkPurchasedProducts() {
        StartCoroutine(FormirateMarkingPurchasedProductsRequest());
    }

    private IEnumerator FormirateMarkingPurchasedProductsRequest() {
        List<string> productsIds = new List<string>();

        foreach(GameObject product in _productsContainer.TakeHighlightedProductsToDelete()) {
            ProductData productData = product.GetComponent<ProductContent>().TakeProductInfo();
            productsIds.Add(productData.productId);
        }
        
        Dictionary<string, string> purchasedProducts = new Dictionary<string, string>() {{APIConfig.poductId_NameOfVariableInDatabase, string.Join(",", productsIds)}};

        yield return StartCoroutine(_createProductRequest.SendPostAPIRequest(purchasedProducts, _additionalURL));

        _fillCart.UpateCartFills();
    }
}