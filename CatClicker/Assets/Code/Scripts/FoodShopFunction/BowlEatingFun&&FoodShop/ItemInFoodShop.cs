using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemInFoodShop : MonoBehaviour
{
    [Header("Name Food")]
    [SerializeField]private string Namefood;
    private TMP_Text namefood;

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
        namefood = transform.Find("Name").GetComponent<TMP_Text>();
        price = transform.Find("Price").GetComponent<TMP_Text>();

        namefood.text = Namefood;
        price.text = Price.ToString();
    }

    void Update()
    {
        if (GameManager.instance.Money >= Price)
        {
            price.color = Color.green;
        }
        else
        {
            price.color = Color.red;
        }
    }

    private void BuyProduct()
    {
        if (Price <= GameManager.instance.Money)
        {
            BowlEQ.instance.AddItemInList(food);
            GameManager.instance.BuyProduct(Price);
        }
    }
}
