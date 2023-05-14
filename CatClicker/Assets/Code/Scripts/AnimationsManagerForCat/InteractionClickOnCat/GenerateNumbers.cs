using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNumbers : MonoBehaviour
{
    public GameObject prefabNumbers;

    public void GenerateNumberOnCat()
    {
        Instantiate(prefabNumbers, Input.mousePosition, Quaternion.identity, transform);
        if (GameManager.instance.DetectCrit == true)
        {
            float CritAmount = GameManager.instance.AmountOnClick * GameManager.instance.MultiplierCrit;
            prefabNumbers.GetComponent<TMP_Text>().text = "Critical " + CritAmount.ToString("F2");
            prefabNumbers.GetComponent<TMP_Text>().color = Color.red;
        }
        else
        {
            prefabNumbers.GetComponent<TMP_Text>().text = GameManager.instance.AmountOnClick.ToString("F2");
            prefabNumbers.GetComponent<TMP_Text>().color = Color.white;
        }
    }
}
