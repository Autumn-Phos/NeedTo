using System.Collections.Generic;
using System.Collections;
using CutsomRequests;
using UnityEngine;

public class PostProductsIds : MonoBehaviour {
    private CreateProductRequest _createProductRequest => FindObjectOfType<CreateProductRequest>();

    [SerializeField] private ProductsContainer _productsContainer;
    [SerializeField] private string _additionalURL;
    [SerializeField] private FillCart _fillCart;

    public void StartPostProductsIds() {
        StartCoroutine(FormiratePostProductsIdsRequest());
    }

    private IEnumerator FormiratePostProductsIdsRequest() {
        List<string> productsIds = new List<string>();

        foreach(GameObject product in _productsContainer.TakeHighlightedProductsToDelete()) {
            ProductData productData = product.GetComponent<ProductContent>().TakeProductInfo();
            productsIds.Add(productData.productId);
        }
        print(string.Join(",", productsIds));
        
        Dictionary<string, string> postProducts = new Dictionary<string, string>() {{APIConfig.productId_NameOfVariableInDatabase, string.Join(",", productsIds)}};

        yield return StartCoroutine(_createProductRequest.SendPostAPIRequest(postProducts, _additionalURL));

        _fillCart.UpateCartFills();
    }
}