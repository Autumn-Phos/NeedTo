using System.Collections.Generic;
using System.Collections;
using ToastFactory;
using UnityEngine;

public class FillCart : MonoBehaviour {
    private enum FillCartOptions {
        GetPurchase,
        GetPurchaseHistory
    };

    private GetProducts _getProducts => FindObjectOfType<GetProducts>();

    [SerializeField] private FillCartOptions _fillCartOption;
    [SerializeField] private Transform _cartDataContentTransform;
    [SerializeField] private GameObject _productPrefab;
    [SerializeField] private ProductsContainer _productsContainer;

    private void Start()
    {
        UpateCartFills();
    }

    public void UpateCartFills() {
        ClearCartFills();

        StartCoroutine(GetAPIResponseAndConvertToProductList());
    }

    private IEnumerator GetAPIResponseAndConvertToProductList() {
        if (FillCartOptions.GetPurchase == _fillCartOption) {
            yield return StartCoroutine(_getProducts.StartFormirateProductRequest(false));
        }
        else if (FillCartOptions.GetPurchaseHistory == _fillCartOption) {
            yield return StartCoroutine(_getProducts.StartFormirateProductRequest(true));
        }
        
        string APIResponse = _getProducts.GetAPIResponse();
        ProductList playerData = JsonUtility.FromJson<ProductList>(APIResponse);

        SpawnProducts(playerData);
    }

    private void SpawnProducts(ProductList productList) {
        _productsContainer.ClearProductList();
        
        GameObject newProduct;

        if (productList.products != null && productList.products.Count > 0) {
            foreach (ProductData product in productList.products) {
                newProduct = Instantiate(_productPrefab, _cartDataContentTransform);
                newProduct.transform.SetParent(_cartDataContentTransform);

                _productsContainer.FillProductList(newProduct);

                newProduct.GetComponent<ProductContent>().FillProductInfo(product);
            }
        } else {
            ToastMaker.MakeAToast("Список продуктов пуст!", true, 4);
        }
    }

    private void ClearCartFills() {
        foreach (Transform child in _cartDataContentTransform) {
            Destroy(child.gameObject);
        }
    }
}

[System.Serializable]
public class ProductList {
    public List<ProductData> products;
}

[System.Serializable]
public struct ProductData {
    public string productId;
    public string productName;
    public string productQuantity;
    public string productShopName;
    public string productPriority;
}