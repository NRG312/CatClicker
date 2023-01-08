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

    [Header("CatImageToclick Parameters")]
    public Button Image;
    private Animator AnimImage;
    [HideInInspector] public float AmountOnClick = 0.5f;
    [HideInInspector] public float PassiveMoney;
    private void RefreshUI()
    {
        TextMoney.text = Money.ToString("F1");
    }
    void Start()
    {
        instance = this;
        
        StartCoroutine(PassiveGrowth());
        
        Image.onClick.AddListener(MoneyGrowthOnClick);
        AnimImage = Image.GetComponent<Animator>();
    }
    //On Click Money Growth and Turning Animation Cat
    public void MoneyGrowthOnClick()
    {
        Money += AmountOnClick;
        AnimImage.SetTrigger("Click");
    }
    public void IncreaseStatistics(float Price)
    {
        Money -= Price;
        RefreshUI();
    }
    public void BuyUpgradesOnTap(float Price,float Amount)
    {
        Money -= Price;
        RefreshUI();
    }
    public void BuyUpgradesPassive(float Price,float Amount)
    {
        Money -= Price;
        PassiveMoney += Amount;
        RefreshUI();
    }
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
