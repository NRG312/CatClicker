using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Money Parameters")]
    public TMP_Text textMoney;
    private float actualMoney = 0;
    public float Money
    {
        get { return actualMoney; }
        set 
        {
            if (value < 0)
            {
                Debug.Log("Not Enough Money");
                value = actualMoney;
            }
            // Convert Big Numbers
            if (value < 1000)
            {
                textMoney.text = Money.ToString("F1");
            }
            else if (value < 1000000)
            {
                float number = Money / 1000;
                textMoney.text = number.ToString("F1") + "K";
            }
            else if (value < 1000000000)
            {
                float number = Money / 1000000;
                textMoney.text = number.ToString("F1") + "M";
            }
            //
            actualMoney = value;
        }
    }

    [Header("CatImage click Parameters")]
    public Button Image;
    [HideInInspector]public bool CanClickOnCat;
    
    [Header("OnClick Increase Money Parameters")]
    [Range(0,1)] public float chanceforCrit;
    public float multiplierCrit;
    [HideInInspector] public bool detectCrit;
    [HideInInspector] public float amountOnClick = 0.5f;
    [HideInInspector] public float passiveMoney;
    
    //Data Values
    private float _timeSave;
    private bool _firstSave;
    //
    void Start()
    {
        instance = this;
        //Starting Couroutines
        StartCoroutine(PassiveGrowth());
        
        //Image cat to click to money growth
        Image.onClick.AddListener(MoneyGrowthOnClick);
    }

    //MoneyFuntions
    public void MoneyGrowthOnClick()
    {
        if (Random.value > chanceforCrit)
        {
            detectCrit = true;
            Money += amountOnClick * multiplierCrit;
            GameObject.Find("GameController").GetComponent<AnimationsManagerCat>().AnimationOnClickToGrowthMoney();
            
        }
        else
        {
            detectCrit = false;
            Money += amountOnClick;
            GameObject.Find("GameController").GetComponent<AnimationsManagerCat>().AnimationOnClickToGrowthMoney();
        }
    }
    private IEnumerator PassiveGrowth()
    {
        bool isPassiveOn = true;
        while (isPassiveOn == true)
        {
            yield return new WaitForSeconds(1);
            Money += passiveMoney;
        }
    }
    //
    //Checking Image cat interactable
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
        }
        //Checking that living room is showing
        if (CanClickOnCat == true)
        {
            Image.interactable = true;
        }
        else
        {
            Image.interactable = false;
        }
    }
    //Functions To buy upgrades from Upgrades Script
    public void BuyUpgradesOnTap(float Price,float Amount)
    {
        Money -= Price;
        amountOnClick += Amount;
    }
    public void BuyUpgradesPassive(float Price,float Amount)
    {
        Money -= Price;
        passiveMoney += Amount;
    }
    //Buying Products
    public void BuyProduct(float Price)
    {
        Money -= Price;
    }
    
    
}
