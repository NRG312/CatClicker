using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BowlEQ : MonoBehaviour
{
    private Dictionary<Food, int> inventory = new Dictionary<Food, int>();
    public static BowlEQ instance;

    public GameObject[] Slots;
    [Header("ToCreateItemInEQ")]
    public GameObject Itemprefab;

    #region PropertiesInventory

    public Dictionary<Food, int> GetInventory => inventory;
    
    #endregion
    void Start()
    {
        instance = this;

        InventoryAndDataSaveSystem save = FindObjectOfType<InventoryAndDataSaveSystem>();
        if (save)
        {
            foreach (var itemAndCount in save.LoadInventory())
            {
                inventory.Add(itemAndCount.Key,itemAndCount.Value);
            }
        }
    }
    //mialem plany na ta funkcje kiedys moze sie przyda
    public void AddItemInList(Food item)
    {
        CreateItemInEQ(item,1);
    }
    //on buy item is creating
    public void CreateItemInEQ(Food item, int count)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            GameObject slot = Slots[i];
            ItemPrefab IteminSlot = slot.GetComponentInChildren<ItemPrefab>();
            
            if (IteminSlot == null)
            {
                GameObject obj = Instantiate(Itemprefab, slot.transform);
                ItemPrefab prefab = obj.GetComponent<ItemPrefab>();
                prefab.SwitchParameters(item);
                
                inventory.Add(item,count);
                return;
            }
            if (IteminSlot != null && IteminSlot.item == item)
            {
                inventory[item] += count;
                IteminSlot.AddAmount(+1);
                return;
            }
        }
    }

    //Load Saved Foods to EQ
    public void LoadSaveInventory(Food item, int count)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            GameObject slot = Slots[i];
            ItemPrefab IteminSlot = slot.GetComponentInChildren<ItemPrefab>();
            
            if (IteminSlot == null)
            {
                GameObject obj = Instantiate(Itemprefab, slot.transform);
                ItemPrefab prefab = obj.GetComponent<ItemPrefab>();
                prefab.SwitchParameters(item);
                prefab.AmountItem = count;
                
                inventory.Add(item,count);
                return;
            }
            if (IteminSlot != null && IteminSlot.item == item)
            {
                inventory[item] += count;
                return;
            }
        }
    }
}
