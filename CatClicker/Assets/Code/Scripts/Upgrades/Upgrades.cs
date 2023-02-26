using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    private Button Upgrade;
    [Header("To Change Text")]
    public string Nameupgrade;
    private TMP_Text NameUpgrade;

    public string Whatwillgive;
    private TMP_Text WhatWillGive;

    [Header("Price")]
    [SerializeField] private float Price = 5f;//
    [SerializeField] private float MultiplierPrice;//
    private TMP_Text PriceTxt;
    [Header("UpgradesOnTap")]
    [SerializeField] private float UpgradeOnTap;//
    [Header("PassiveUpgrades")]
    [SerializeField] private float PassiveUpgrade;//
    [SerializeField] private bool IsPassiveUpgrade;
    //Amount
    private TMP_Text AmountTxt;
    private int ActualAmount;//

    void Start()
    {
        //Texts to change
        NameUpgrade = transform.Find("UpgradeName").GetComponent<TMP_Text>();
        WhatWillGive = transform.Find("UpgradeGiving").GetComponent<TMP_Text>();

        NameUpgrade.text = Nameupgrade;
        WhatWillGive.text = Whatwillgive;

        //Basic functions
        Upgrade = transform.Find("BuyButton").GetComponent<Button>();
        PriceTxt = transform.Find("Price").GetComponent<TMP_Text>();
        AmountTxt = transform.Find("Amount").GetComponent<TMP_Text>();

        Upgrade.onClick.AddListener(OnClick);
        RefreshUI();
    }
    private void RefreshUI()
    {
        PriceTxt.text = "Price " + Price.ToString("F2");
        AmountTxt.text = ActualAmount.ToString();
    }
    private void OnClick()
    {
        if (GameManager.instance.Money >= Price && IsPassiveUpgrade == false)
        {
            GameManager.instance.BuyUpgradesOnTap(Price,UpgradeOnTap);
            IncreasePrice();
            ChangeAmountText(1);
            RefreshUI();
        }
        //
        if (GameManager.instance.Money >= Price && IsPassiveUpgrade == true)
        {
            GameManager.instance.BuyUpgradesPassive(Price, PassiveUpgrade);
            IncreasePrice();
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
        MultiplierPrice += 0.15f;
        float increaseprice = Price * MultiplierPrice;
        Price += increaseprice;
    }
    /*private void IncreaseOnTap()
    {

    }
    private void IncreaseOnPassive()
    {

    }*/       //zapytaj sie na spotkaniu w jaki sposob bedzie sie zwiekszal mnoznik punktow zdonywanych
}
