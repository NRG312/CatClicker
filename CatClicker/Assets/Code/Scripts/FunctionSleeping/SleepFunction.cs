using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepFunction : MonoBehaviour
{
    public GameObject CatObj;
    public GameObject SleepingCatObj;
    public GameObject CarpetObj;

    //Components Cat to swap
    private Image EarsCat;
    private Image EyesBlushNoseCat;
    private Image MouthCat;
    //Components SleepingCatObj
    private Image EarsSleep;
    private Image EyesBlushNoseSleep;
    private Image MouthSleep;

    private void Update()
    {
        if (FunctionStatistics.instance.loopSleep == false)
        {
            GameObject.Find("RoomsController").GetComponent<FunctionStatistics>().SleepFunction();
        }
    }
    public void StartRegeneration()
    {
        EarsCat = CatObj.transform.Find("Ears").GetComponent<Image>();
        //EyesBlushNoseCat = CatObj.transform.Find("Eyes,Blush,Nose").GetComponent<Image>(); //zbagowane narazie oczy sa otwarte przez ta zmiane
        MouthCat = CatObj.transform.Find("Mouth").GetComponent<Image>();

        CatObj.transform.gameObject.SetActive(false);
        SleepingCatObj.transform.gameObject.SetActive(true);

        MouthSleep = SleepingCatObj.transform.Find("Mouth").GetComponent<Image>();
        //EyesBlushNoseSleep = SleepingCatObj.transform.Find("Eyes,Blush,Nose").GetComponent<Image>();
        EarsSleep = SleepingCatObj.transform.Find("Ears").GetComponent<Image>();
        MouthSleep.sprite = MouthCat.sprite;
        //EyesBlushNoseSleep.sprite = EyesBlushNoseCat.sprite;
        EarsSleep.sprite = EarsCat.sprite;

        FunctionStatistics.instance.loopSleep = false;
        Swapping.instance.BlockSwap = true;
    }
    public void EndRegeneration()
    {
        CatObj.transform.gameObject.SetActive(true);
        SleepingCatObj.transform.gameObject.SetActive(false);

        FunctionStatistics.instance.loopSleep = true;
        Swapping.instance.BlockSwap = false;
    }
}
