using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProductContent : MonoBehaviour {
    [SerializeField] private bool _isSelectToggleActive;
    private ProductData _productInfo;

    [SerializeField] private List<Color> _priorityColor = new List<Color>();

    public void FillProductInfo(ProductData product) {
        TextMeshProUGUI[] texts = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = product.productName;
        texts[1].text = product.productQuantity + APIConfig.quantityType;
        texts[2].text = product.productShopName;
        texts[4].text = product.productPriority;
        ChangeProductPriorityColor(int.Parse(product.productPriority));

        _productInfo = product;
    }

    private void ChangeProductPriorityColor(int productPriority) {
        gameObject.GetComponent<Image>().color = _priorityColor[productPriority];
    }

    public void ChangePropertyIsSelectToggleActive(Toggle toggle) {
        _isSelectToggleActive = toggle.isOn;
    }

    public bool TakeIsSelectToggleActive() {
        return _isSelectToggleActive;
    }

    public ProductData TakeProductInfo() {
        return _productInfo;
    }
}