using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradesRooms : MonoBehaviour
{
    private enum TypeOfUpgrade { Wall, Floor }
    [Header("Main Parameters")]
    [SerializeField] private TypeOfUpgrade typeOfUpgrade;
    [SerializeField] private Sprite Image;
    [SerializeField] private string typeOfProduct;
    [SerializeField] private float priceOfProduct;
    //Buttons Parameters
    private Button buyButton;
    private Button selectButton;


    [Header("Texts Parameters")]
    [SerializeField] private string NameTxt;
    private TMP_Text Name;
    private TMP_Text Price;
    void Start()
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
        if (typeOfUpgrade == TypeOfUpgrade.Wall)
        {
            CustomizationGame.instance.CheckingTypeOfProduct(Image, typeOfProduct);
        }
    }
}
