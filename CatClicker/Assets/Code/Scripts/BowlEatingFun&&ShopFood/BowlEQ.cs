using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BowlEQ : MonoBehaviour
{
    public static BowlEQ instance;

    public Food[] ListFood;
    [Header("ToCreateItemInEQ")]
    public GameObject Content;
    public GameObject Item;
    [Header("TextIsEmpty")]
    public TMP_Text TextIsEmpty;
    void Start()
    {
        instance = this;
    }
    public void AddItemInList(Food item)
    {
        //Wymysl cos potem z ta lista czy robic ja czy nie
        //i czy bedzie amount to wtedy tutaj tez sprawdzi czy juz bylo zakupione
        CreateItemInEQ(item);
    }
    private void CreateItemInEQ(Food item)
    {
        GameObject obj = Instantiate(Item, Content.transform);
        ItemPrefab prefab = obj.GetComponent<ItemPrefab>();
        prefab.SwitchParameters(item);
    }
}
