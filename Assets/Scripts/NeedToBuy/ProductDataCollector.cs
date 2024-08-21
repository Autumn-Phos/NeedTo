using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProductDataCollector : MonoBehaviour
{
    [SerializeField] private ProductInfo[] ProductInfo;
    [SerializeField] private ChoosePriority _choosePriority;

    public Dictionary<string, string> CollectProductInfo() {
        Dictionary<string, string> productData = new Dictionary<string, string>();

        foreach(ProductInfo data in ProductInfo) {
            productData.Add(data.GetNameOfProductInfoType(), data.GetTextFieldWithProductInfo().ToString());
        }

        if (_choosePriority !=null) {
            productData.Add(APIConfig.productPryority_NameOfVariableInDatabase, _choosePriority.GetSelectedPriorityNumber().ToString());
        }
        
        return productData;
    }
}

[System.Serializable]
public class ProductInfo
{
    [SerializeField] private string _nameOfProductInfoType;
    [SerializeField] private TMP_InputField _textFieldWithProductInfo;

    public string GetNameOfProductInfoType() {
        return _nameOfProductInfoType;
    }

    public string GetTextFieldWithProductInfo() {
        return _textFieldWithProductInfo.text;
    }

    public void ClearTextFieldWithProductInfo() {
        _textFieldWithProductInfo.text = "";
    }
}