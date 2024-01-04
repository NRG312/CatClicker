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
        private set 
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
    float timeSave;
    bool firstSave;
    //
    void Start()
    {
        instance = this;
        //Starting Couroutines
        StartCoroutine(PassiveGrowth());
        
        //Image cat to click to money growth
        Image.onClick.AddListener(MoneyGrowthOnClick);
        
        //Checking first save in Game
        if (PlayerPrefs.GetInt("FirstSave") == 1)
        {
            firstSave = true;
        }
        //Load data
        LoadSaveData();
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
        //Save Game
        timeSave += Time.deltaTime;
        if (timeSave >= 3)
        {
            SaveData();
            timeSave = 0;
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
    //
    //Load data
    private void LoadSaveData()
    {
        if (firstSave)
        {
            //Upgrades
            float amountClick = PlayerPrefs.GetInt("OnClickUpgrade");
            float amountPassive = PlayerPrefs.GetInt("PassiveUpgrade");
            //
            //Main Values
            float _money = PlayerPrefs.GetFloat("Money");
            //float _premiumMoney = PlayerPrefs.GetFloat("PremiumMoney");
            //
            //Stats Values
            int _sleep = PlayerPrefs.GetInt("Sleep");
            int _hunger = PlayerPrefs.GetInt("Hunger");
            int _wc = PlayerPrefs.GetInt("WC");
            int _hygiene = PlayerPrefs.GetInt("Hygiene");
            FindObjectOfType<FunctionStatistics>().LoadSavedStats(_sleep,_hunger,_wc,_hygiene);
            //
            //Refresh Values
            amountOnClick += amountClick;
            passiveMoney += amountPassive;
            Money = _money;
            //
        }
        
    }
    //Save data
    private void SaveData()
    {
        if (firstSave == false)
        {
            PlayerPrefs.SetInt("FirstSave",1);
        }
        
        PlayerPrefs.SetFloat("Money",Money);
        PlayerPrefs.SetInt("Sleep",FunctionStatistics.instance.sleep);
        PlayerPrefs.SetInt("Hunger",FunctionStatistics.instance.hunger);
        PlayerPrefs.SetInt("WC",FunctionStatistics.instance.wc);
        PlayerPrefs.SetInt("Hygiene",FunctionStatistics.instance.hygiene);
    }
    //
}
