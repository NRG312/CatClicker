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
    [SerializeField] private string typeOfProduct;
    [SerializeField] private float priceOfProduct;
    //UI Buttons in Upgrade
    private Button selectButton;
    private Button buyButton;
    [Header("Name Of Upgrade")]
    [SerializeField] private string NameTxt;
    private TMP_Text Name;
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

        Price.text = priceOfProduct.ToString();
        
        //load data
        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            selectButton.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (GameManager.instance.Money >= priceOfProduct)
        {
            Price.color = Color.green;
        }
        else
        {
            Price.color = Color.red;
        }
    }
    private void BuyProduct()
    {
        if (GameManager.instance.Money >= priceOfProduct)
        {
            GameManager.instance.BuyProduct(priceOfProduct);
            selectButton.gameObject.SetActive(true);
            PlayerPrefs.SetInt(gameObject.name,1);
        }
    }
    private void SelectProduct()
    {
        if (newImage == null)
        {
            TakeOffProduct();
        }
        else
        {
            CustomizationGame.instance.ChangeApperanceCat(newImage, typeOfProduct);
            if (Clip != null)
            {
                AnimationsManagerCat.instance.ChangeAnimationClipOnClick(Clip, typeOfProduct);
            }
        }
    }

    private void TakeOffProduct()
    {
        CustomizationGame.instance.TakeOffApperanceItem(typeOfProduct);
    }
}
