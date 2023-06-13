using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationInShop : MonoBehaviour
{
    [Header("Shop Parameters")]
    public Button Shop;
    public Canvas shopCan;
    private int countShop;
    [Header("Settings Parameters")]
    public Button Settings;
    public Canvas setCan;
    private int countSett;


    private void Start()
    {
        Shop.onClick.AddListener(CountingShop);
        //Settings.onClick.AddListener(CountingSettings);
    }

    private void CountingShop()
    {
        countShop++;
        if (countShop == 1)
        {
            shopCan.gameObject.SetActive(true);
        }
        else if (countShop == 2)
        {
            shopCan.gameObject.SetActive(false);
            countShop = 0;
        }
    }
    private void CountingSettings()
    {
        countSett++;
        if (countSett == 1)
        {
            setCan.enabled = true;
        }
        else if (countSett == 2)
        {
            setCan.enabled = false;
            countSett = 0;
        }
    }
}
