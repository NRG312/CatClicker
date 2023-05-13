using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesApperance : MonoBehaviour
{
    [Header("Main Parameters")]
    [SerializeField] private AnimationClip Clip;
    [SerializeField] private Sprite newImage;
    [SerializeField] private string TypeOfProduct;
    [SerializeField] private float PriceOfProduct;
    //UI Buttons in Upgrade
    private Button selectButton;
    private Button buyButton;
    [Header("Texts In Upgrade")]
    [SerializeField] private string NameTxt;
    private TMP_Text Name;

    [SerializeField] private string PriceTxt;
    private TMP_Text Price;

    private void Start()
    {
        //Buttons
        buyButton = transform.Find("BuyButton").GetComponent<Button>();
        selectButton = transform.Find("SelectButton").GetComponent<Button>();
        buyButton.onClick.AddListener(BuyProduct);
        selectButton.onClick.AddListener(SelectProduct);
        //Texts
        Name = transform.Find("Texts").transform.Find("Name").GetComponent<TMP_Text>();
        Name.text = NameTxt;
        Price = transform.Find("Texts").transform.Find("Price").GetComponent<TMP_Text>();
        Price.text = PriceTxt;
    }
    private void BuyProduct()
    {
        if (GameManager.instance.Money >= PriceOfProduct)
        {
            GameManager.instance.BuyProduct(PriceOfProduct);
            selectButton.gameObject.SetActive(true);
        }
    }
    private void SelectProduct()
    {
        CustomizationGame.instance.ChangeApperanceCat(newImage, TypeOfProduct);
        AnimationsManagerCat.instance.ChangeAnimationClipOnClick(Clip, TypeOfProduct);
    }
}
