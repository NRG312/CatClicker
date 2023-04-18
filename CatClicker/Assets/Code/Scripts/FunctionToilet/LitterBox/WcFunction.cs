using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WcFunction : MonoBehaviour
{
    public GameObject CatObj;

    public GameObject BowlPosition;

    private bool RegenerationWC;

    private void Update()
    {
        if (RegenerationWC == true)
        {
            GameObject.Find("RoomsController").GetComponent<FunctionStatistics>().WCFunction();
        }
    }
    public void StartRegeneration()
    {
        CatObj.transform.position = transform.position + new Vector3(20, 135);
        CatObj.transform.localScale -= new Vector3(0.5f, 0.5f);
        RegenerationWC = true;
    }
    public void EndRegeneration()
    {
        RegenerationWC = false;

        CatObj.transform.position = BowlPosition.transform.position + new Vector3(0,35);
        CatObj.transform.localScale += new Vector3(0.5f, 0.5f);
    }
}
