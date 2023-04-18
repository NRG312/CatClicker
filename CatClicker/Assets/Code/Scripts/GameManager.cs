using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Money Parameters")]
    public TMP_Text TextMoney;
    private float ActualMoney = 0;
    public float Money
    {
        get { return ActualMoney; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Not Enough Money");
                value = ActualMoney;
            }
            TextMoney.text = Money.ToString("F1");
            ActualMoney = value;
        }
    }

    [Header("CatImage click Parameters")]
    public Button Image;
    public bool CanClickOnCat;
    
    [Header("OnClick Increase Money Parameters")]
    [Range(0,1)]public float chanceforCrit;
    public float MultiplierCrit;
    [HideInInspector]public float AmountOnClick = 0.5f;
    [HideInInspector]public float PassiveMoney;
    
    private void RefreshUI()
    {
        TextMoney.text = Money.ToString("F1");
    }
    void Start()
    {
        instance = this;
        
        StartCoroutine(PassiveGrowth());
        
        //Image cat to click to money growth
        Image.onClick.AddListener(MoneyGrowthOnClick);
    }

    //Checking Image cat interactable
    private void Update()
    {
        if (CanClickOnCat == true)
        {
            Image.interactable = true;
        }
        else
        {
            Image.interactable = false;
        }
    }
    //On Click Money Growth and Turning Animation Cat
    public void MoneyGrowthOnClick()
    {
        if (Random.value > chanceforCrit)
        {
            Debug.Log("Crit");
            Money += AmountOnClick * MultiplierCrit;
            GameObject.Find("GameController").GetComponent<AnimationsManagerCat>().AnimationOnClickToGrowthMoney();
            
        }
        else
        {
            Money += AmountOnClick;
            GameObject.Find("GameController").GetComponent<AnimationsManagerCat>().AnimationOnClickToGrowthMoney();
        }
    }
    //Functions To buy upgrades from Upgrades Script
    public void BuyUpgradesOnTap(float Price,float Amount)
    {
        Money -= Price;
        AmountOnClick += Amount;
        RefreshUI();
    }
    public void BuyUpgradesPassive(float Price,float Amount)
    {
        Money -= Price;
        PassiveMoney += Amount;
        RefreshUI();
    }
    //
    private IEnumerator PassiveGrowth()
    {
        bool s = true;
        while (s == true)
        {
            yield return new WaitForSeconds(1);
            Money += PassiveMoney;
            RefreshUI();
        }
    }

}
