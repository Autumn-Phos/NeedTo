using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProductDataCollector : MonoBehaviour
{
    [SerializeField] private ProductInfo[] ProductInfo;
    [SerializeField] private ChooseOneOfTheOptions _chooseOneOfTheOptions;

    public Dictionary<string, string> CollectProductInfo() {
        Dictionary<string, string> productData = new Dictionary<string, string>();

        foreach(ProductInfo data in ProductInfo) {
            productData.Add(data.GetNameOfProductInfoType(), data.GetTextFieldWithProductInfo().ToString());
        }

        if (_chooseOneOfTheOptions !=null) {
            productData.Add(APIConfig.productPryority_NameOfVariableInDatabase, _chooseOneOfTheOptions.GetSelectedOptionNumber().ToString());
        }
        
        ClearInputFieldData();
        return productData;
    }

    private void  ClearInputFieldData() {
        foreach(ProductInfo data in ProductInfo) {
            data.ClearTextFieldWithProductInfo();
        }
        _chooseOneOfTheOptions.SetDefaultOption();
        Debug.Log("ProductActionFrame - all field change value to default");
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