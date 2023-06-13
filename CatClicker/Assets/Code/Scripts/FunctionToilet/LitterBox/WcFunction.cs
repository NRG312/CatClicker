using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WcFunction : MonoBehaviour
{
    public GameObject CatObj;

    public GameObject BowlPosition;

    private void Update()
    {
        if (FunctionStatistics.instance.loopWc == false)
        {
            FunctionStatistics.instance.WCFunction();
        }
    }
    public void StartRegeneration()
    {
        CatObj.transform.position = transform.position + new Vector3(20, 135);
        CatObj.transform.localScale -= new Vector3(0.5f, 0.5f);

        FunctionStatistics.instance.loopWc = false;
        Swapping.instance.blockSwap = true;
    }
    public void EndRegeneration()
    {
        Swapping.instance.blockSwap = false;
        FunctionStatistics.instance.loopWc = true;

        CatObj.transform.position = BowlPosition.transform.position + new Vector3(7,125);
        CatObj.transform.localScale += new Vector3(0.5f, 0.5f);
    }
}
