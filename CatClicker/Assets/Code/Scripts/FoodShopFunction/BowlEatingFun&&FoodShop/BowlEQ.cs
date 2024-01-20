using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BowlEQ : MonoBehaviour
{
    private Dictionary<Food, int> inventory = new Dictionary<Food, int>();
    public static BowlEQ instance;

    //public GameObject[] Slots;
    public List<GameObject> Slots;
    [Header("To Create Item In EQ")]
    public GameObject itemPrefab;
    [Header("To Create Slots")] 
    public GameObject slotPrefab;

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
    //on buy item is creating
    public void CreateItemInEQ(Food item, int count)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            GameObject slot = Slots[i];
            ItemPrefab IteminSlot = slot.GetComponentInChildren<ItemPrefab>();
            
            if (IteminSlot == null)
            {
                GameObject obj = Instantiate(itemPrefab, slot.transform);
                ItemPrefab prefab = obj.GetComponent<ItemPrefab>();
                prefab.SwitchParameters(item);
                
                inventory.Add(item,count);
                return;
            }
            if (IteminSlot != null && IteminSlot.item == item)
            {
                inventory[item] += count;
                IteminSlot.AddAmount(1);
                return;
            }
        }
    }
    //on Use Food Remove Amount From List
    public void DecreaseAmountFromList(Food item)
    {
        inventory[item] -= 1;
    }
    //Load Saved Foods to EQ
    public void LoadSaveInventory(Food item, int count)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            GameObject slot = Slots[i];
            ItemPrefab itemInSlot = slot.GetComponentInChildren<ItemPrefab>();
            if (itemInSlot == null)
            {
                GameObject obj = Instantiate(itemPrefab, slot.transform);
                ItemPrefab prefab = obj.GetComponent<ItemPrefab>();
                prefab.SwitchParameters(item);
                prefab.AmountItem = count;
                
                inventory.Add(item,count);
                return;
            }

            if (itemInSlot != null && itemInSlot.item == item)
            {
                return;
            }
        }
    }
    //When the slot food is empty
    public void RefreshSlots(GameObject slot,Transform parentSlot,Food item)
    {
        inventory.Remove(item);
        
        Slots.Remove(slot);
        Destroy(slot);
        
        GameObject newSlot = Instantiate(slotPrefab, parentSlot);
        Slots.Add(newSlot);
    }
}
