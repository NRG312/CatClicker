using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.iOS;
public class InventoryAndDataSaveSystem : MonoBehaviour
{
    //Data Values
    private float _timeSave;
    private bool _firstSave;
    //
    //Inventory FoodShop Values
    private static Dictionary<Food, int> allItemCodes = new Dictionary<Food, int>();
    private static int HashItem(Food item) => Animator.StringToHash(item.NameFood);
    private static string filePath = "Null";
    private const string split_char = "_";
    

    private void Awake()
    {
        //Creating new File
        filePath = Application.persistentDataPath + "/Inventory.txt";
        if (!File.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        CheckingDictionaryItems();
        
        //Checking first save in Game
        if (PlayerPrefs.GetInt("FirstSave") == 1)
        {
            _firstSave = true;
        }
        //Load data
        LoadSaveData();
    }

    private void Update()
    {
        //Save Game
        _timeSave += Time.deltaTime;
        if (_timeSave >= 3)
        {
            SaveData();
            _timeSave = 0;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            SaveInventory();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadInventory();
        }
    }

    //Basic Saving & loading Data
    //Load data
    private void LoadSaveData()
    {
        if (_firstSave)
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
            FindObjectOfType<GameManager>().amountOnClick += amountClick;
            FindObjectOfType<GameManager>().passiveMoney += amountPassive;
            FindObjectOfType<GameManager>().Money = _money;
            //
        }
        
    }
    //Save data
    private void SaveData()
    {
        if (_firstSave == false)
        {
            PlayerPrefs.SetInt("FirstSave",1);
        }
        
        PlayerPrefs.SetFloat("Money",GameManager.instance.Money);
        PlayerPrefs.SetInt("Sleep",FunctionStatistics.instance.sleep);
        PlayerPrefs.SetInt("Hunger",FunctionStatistics.instance.hunger);
        PlayerPrefs.SetInt("WC",FunctionStatistics.instance.wc);
        PlayerPrefs.SetInt("Hygiene",FunctionStatistics.instance.hygiene);
    }
    
    //Basic Loading & Saving Inventory FoodShop
    private void CheckingDictionaryItems()
    {
        Food[] allItems = Resources.FindObjectsOfTypeAll<Food>();
        foreach (Food i in allItems)
        {
            int key = HashItem(i);
            /*if (!allItemCodes.ContainsKey(key))
            {
                allItemCodes.Add(key,i);
            }*/
        }
    }

    internal void SaveInventory()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (KeyValuePair<Food,int> s in BowlEQ.instance.GetInventory)
            {
                Food item = s.Key;
                int count = s.Value;

                string itemID = HashItem(item).ToString();
                sw.WriteLine(itemID + split_char + count);
            }
        }
    }

    internal Dictionary<Food,int> LoadInventory()
    {
        Dictionary<Food, int> inventory = new Dictionary<Food, int>();
        if (!File.Exists(filePath))
        {
            Debug.Log("nie dziala");
        }

        string line = "";
        using (StreamReader sr = new StreamReader(filePath))
        {
            while ((line = sr.ReadLine()) != null)
            {
                int key = int.Parse(line.Split(split_char)[0]);
                /*Food item = allItemCodes[key];*/
                int count = int.Parse(line.Split(split_char)[1]);
                
                /*BowlEQ.instance.CreateItemInEQ(item);*/
            }
            
        }

        return inventory;
    }
}
