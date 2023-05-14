using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesSkills : MonoBehaviour
{
    private Button buyButton;
    private enum TypeOfUpgrade { OnTap,Passive}
    [SerializeField]private TypeOfUpgrade typeOfUpgrade;


    [Header("To Change Text")]
    [SerializeField]private string nameUpgrade;
    private TMP_Text Nameupgrade;
    [SerializeField] private string whatWillGive;
    private TMP_Text WhatWillGive;

    [Header("Price")]
    [SerializeField] private float Price = 5f;//
    //[SerializeField] private float MultiplierPrice;//
    private TMP_Text PriceTxt;
    [Header("UpgradesOnTap")]
    [SerializeField] private float increaseOnTap;//
    [Header("PassiveUpgrades")]
    [SerializeField] private float passiveIncrease;//
    //Amount
    private TMP_Text AmountTxt;
    private int ActualAmount;//

    void Start()
    {
        //Texts to change
        Nameupgrade = transform.Find("UpgradeName").GetComponent<TMP_Text>();
        WhatWillGive = transform.Find("UpgradeGiving").GetComponent<TMP_Text>();

        Nameupgrade.text = nameUpgrade;
        WhatWillGive.text = whatWillGive;

        //Basic functions
        buyButton = transform.Find("BuyButton").GetComponent<Button>();
        PriceTxt = transform.Find("Price").GetComponent<TMP_Text>();
        AmountTxt = transform.Find("Amount").GetComponent<TMP_Text>();

        if (typeOfUpgrade == TypeOfUpgrade.OnTap)
        {
            WhatWillGive.text = whatWillGive + " " + increaseOnTap;
        }
        else if(typeOfUpgrade == TypeOfUpgrade.Passive)
        {
            WhatWillGive.text = whatWillGive + " " + passiveIncrease;
        }

        buyButton.onClick.AddListener(OnBuy);
        RefreshUI();
    }
    private void RefreshUI()
    {
        PriceTxt.text = "Price " + Price.ToString("F2");
        AmountTxt.text = ActualAmount.ToString();

        if (typeOfUpgrade == TypeOfUpgrade.OnTap)
        {
            WhatWillGive.text = whatWillGive + " " + increaseOnTap.ToString("F2");
        }
        else if (typeOfUpgrade == TypeOfUpgrade.Passive)
        {
            WhatWillGive.text = whatWillGive + " " + passiveIncrease.ToString("F2");
        }
    }
    //Buying Upgrade
    private void OnBuy()
    {
        if (GameManager.instance.Money >= Price && typeOfUpgrade == TypeOfUpgrade.OnTap)
        {
            GameManager.instance.BuyUpgradesOnTap(Price, increaseOnTap);
            IncreasePrice();
            IncreaseUpgradeAmount();
            ChangeAmountText(1);
            RefreshUI();
        }
        //
        if (GameManager.instance.Money >= Price && typeOfUpgrade == TypeOfUpgrade.Passive)
        {
            GameManager.instance.BuyUpgradesPassive(Price, passiveIncrease);
            IncreasePrice();
            IncreaseUpgradeAmount();
            ChangeAmountText(1);
            RefreshUI();
        }
    }
    private void Update()
    {
        if (GameManager.instance.Money >= Price)
        {
            PriceTxt.color = Color.green;
        }
        else
        {
            PriceTxt.color = Color.red;
        }
    }

    private void ChangeAmountText(int amount)
    {
        ActualAmount += amount;
    }
    private void IncreasePrice()
    {
        /*MultiplierPrice += 0.15f;
        float increaseprice = Price * MultiplierPrice;
        Price += increaseprice;*/

        if (typeOfUpgrade == TypeOfUpgrade.OnTap)
        {
            if (Price < 100)
            {
                float increaseprice = Price * 2;
                Price += increaseprice;
            }
            else if (Price < 500)
            {
                float increaseprice = Price * 0.9f;
                Price += increaseprice;
            }
            else if (Price < 1500)
            {
                float increaseprice = Price * 0.4f;
                Price += increaseprice;
            }
        }


        if (typeOfUpgrade == TypeOfUpgrade.Passive)
        {
            if (Price < 100)
            {
                float increaseprice = Price * 5;
                Price += increaseprice;
            }
            else if (Price < 500)
            {
                float increaseprice = Price * 3;
                Price += increaseprice;
            }
            else if (Price < 1500)
            {
                float increaseprice = Price * 1.5f;
                Price += increaseprice;
            }
        }

    }
    private void IncreaseUpgradeAmount()
    {
        if (typeOfUpgrade == TypeOfUpgrade.OnTap)
        {
            float amountToIncrease = increaseOnTap * 0.4f;
            increaseOnTap += amountToIncrease;
        }
        else if (typeOfUpgrade == TypeOfUpgrade.Passive)
        {
            float amountToIncrease = passiveIncrease * 0.4f;
            passiveIncrease += amountToIncrease;
        }
    }
}
