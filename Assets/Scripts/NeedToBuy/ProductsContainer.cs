using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProductsContainer : MonoBehaviour {
    private List<GameObject> _productList = new List<GameObject>();

    public List<GameObject> TakeHighlightedProductsToDelete() {
        List<GameObject> highlightedProductsToDelete = new List<GameObject>();

        foreach(GameObject product in _productList) {
            if (product.GetComponent<ProductContent>().TakeIsDeleteToggleActive()) highlightedProductsToDelete.Add(product);
        }

        return highlightedProductsToDelete;
    }

    public void FillProductList(GameObject product) {
        _productList.Add(product);
    }

    public void ClearProductList() {
        _productList.Clear();
    }
}
