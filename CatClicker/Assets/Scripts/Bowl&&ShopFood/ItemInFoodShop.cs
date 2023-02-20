using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInFoodShop : MonoBehaviour
{
    [Header("Name Food")]
    public string Namefood;
    [Header("Image Food")]
    public Sprite ImageFood;
    [Header("PriceFood")]
    public float Price;
    [Header("Item Food")]
    public Food food;

    private Button ButtonToBuy;


    void Start()
    {
        //
        ButtonToBuy = transform.Find("ButtonToBuy").GetComponent<Button>();
        //
        ButtonToBuy.onClick.AddListener(BuyProduct);
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
