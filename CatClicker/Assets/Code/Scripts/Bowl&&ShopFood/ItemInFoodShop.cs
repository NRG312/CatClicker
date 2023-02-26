using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInFoodShop : MonoBehaviour
{
    [Header("Name Food")]
    public string Namefood;
    private TMP_Text namefood;
    [Header("Image Food")]
    public Sprite ImageFood;
    [Header("PriceFood")]
    public float Price;
    private TMP_Text price;
    [Header("Item Food")]
    public Food food;

    private Button ButtonToBuy;


    void Start()
    {
        //
        ButtonToBuy = transform.Find("ButtonToBuy").GetComponent<Button>();
        //
        ButtonToBuy.onClick.AddListener(BuyProduct);
        //
        namefood = transform.Find("NameFood").GetComponent<TMP_Text>();
        price = transform.Find("PriceFood").GetComponent<TMP_Text>();

        namefood.text = Namefood;
        price.text = Price.ToString();
    }

    void Update()
    {
        
    }

    private void BuyProduct()
    {
        if (Price <= GameManager.instance.Money)
        {
            BowlEQ.instance.AddItemInList(food);
        }
    }
}
