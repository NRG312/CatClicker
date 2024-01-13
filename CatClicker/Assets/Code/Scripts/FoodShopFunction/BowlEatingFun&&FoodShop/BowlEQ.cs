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

    #region Properties

    public Dictionary<Food, int> GetInventory => inventory;
    
    #endregion
    void Start()
    {
        instance = this;
    }
    //mialem plany na ta funkcje kiedys moze sie przyda
    public void AddItemInList(Food item)
    {
        CreateItemInEQ(item);
    }
    public void CreateItemInEQ(Food item)
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
                return;
            }
            if (IteminSlot != null && IteminSlot.item == item)
            {
                IteminSlot.AddAmount(1);
                return;
            }
        }
    }
}
