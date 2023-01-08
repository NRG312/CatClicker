using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionStatistics : MonoBehaviour
{
    [Header("StatisticsSlider")]
    [SerializeField] private Slider Hygiene;
    [SerializeField] private Slider WC;
    [SerializeField] private Slider Hunger;
    [SerializeField] private Slider Sleep;

    //Main Amounts for stats
    private int hygiene = 100;
    private int wc = 100;
    private int hunger = 100;
    private int sleep = 100;
    //bools for enumerators
    private bool loopHygiene = true;
    private bool loopWc = true;
    private bool loopHunger = true;
    private bool loopSleep = true;
    //enumerators to stats
    private IEnumerator Reducinghygiene;
    private IEnumerator Reducingwc;
    private IEnumerator Reducinghunger;
    private IEnumerator Reducingsleep;

    [Header("Reducing Hygiene")]
    [SerializeField] private int TimeHygiene;
    [SerializeField] private int AmountHygiene;
    [Header("Reducing WC")]
    [SerializeField] private int TimeWC;
    [SerializeField] private int AmountWC;
    [Header("Reducing Hunger")]
    [SerializeField] private int TimeHunger;
    [SerializeField] private int AmountHunger;
    [Header("Reducing Sleep")]
    [SerializeField] private int TimeSleep;
    [SerializeField] private int AmountSleep;
    [Header("Increase Statistics After Use")]
    [SerializeField] private int IncHygiene;
    [SerializeField] private int IncWC;
    [SerializeField] private int IncHunger;
    [SerializeField] private int IncSleep;
    [Header("Prices for Increase")]
    [SerializeField] private float PriceHygiene;
    [SerializeField] private float PriceWC;
    [SerializeField] private float PriceHunger;
    [SerializeField] private float PriceSleep;

    private void Start()
    {
        Hygiene.value = hygiene;
        WC.value = wc;
        Hunger.value = hunger;
        Sleep.value = sleep;

        Reducinghygiene = ReducingHygiene();
        Reducingwc = ReducingWC();
        Reducinghunger = ReducingHunger();
        Reducingsleep = ReducingSleep();

        StartCoroutine(Reducinghygiene);
        StartCoroutine(Reducingwc);
        StartCoroutine(Reducinghunger);
        StartCoroutine(Reducingsleep);
    }
    private void RefreshUI()
    {
        Hygiene.value = hygiene;
        WC.value = wc;
        Hunger.value = hunger;
        Sleep.value = sleep;
    }

    private void CheckingValueofStats()
    {
        if(hygiene > 0)
        {
            loopHygiene = true;
        }
        if (wc > 0)
        {
            loopWc = true;
        }
        if (hunger > 0)
        {
            loopHunger = true;
        }
        if (sleep > 0)
        {
            loopSleep = true;
        }
        
    }

    public void HygieneFunction()
    {
        if (hygiene < 100)
        {
            if (PriceHygiene <= GameManager.instance.Money)
            {
                GameManager.instance.IncreaseStatistics(PriceHygiene);
                hygiene += IncHygiene;
                RefreshUI();
                CheckingValueofStats();
            }
        }
    }

    private IEnumerator ReducingHygiene()
    {
        while (loopHygiene == true)
        {
            if (hygiene <= 0)
            {
                hygiene = 0;
                loopHygiene = false;
                yield return new WaitUntil(() => loopHygiene);
            }
            yield return new WaitForSeconds(TimeHygiene);
            hygiene -= AmountHygiene;
            RefreshUI();
        }
    }


    public void WCFunction()
    {
        if (wc < 100)
        {
            if (PriceWC <= GameManager.instance.Money)
            {
                GameManager.instance.IncreaseStatistics(PriceWC);
                wc += IncWC;
                RefreshUI();
                CheckingValueofStats();
            }
        }
    }
    private IEnumerator ReducingWC()
    {
        while (loopWc == true)
        {
            if (wc <= 0)
            {
                wc = 0;
                loopWc = false;
                yield return new WaitUntil(() => loopWc);
            }
            yield return new WaitForSeconds(TimeWC);
            wc -= AmountWC;
            RefreshUI();
        }
    }
    

    public void HungerFunction()
    {
        if (hunger < 100)
        {
            if (PriceHunger <= GameManager.instance.Money)
            {
                GameManager.instance.IncreaseStatistics(PriceHunger);
                hunger += IncHunger;
                RefreshUI();
                CheckingValueofStats();
            }
        }
    }
    private IEnumerator ReducingHunger()
    {
        while (loopHunger == true)
        {
            if (hunger <= 0)
            {
                hunger = 0;
                loopHunger = false;
                yield return new WaitUntil(() => loopHunger);
            }
            yield return new WaitForSeconds(TimeHunger);
            hunger -= AmountHunger;
            RefreshUI();
        }
    }
    

    public void SleepFunction()
    {
        if (sleep < 100)
        {
            if (PriceSleep <= GameManager.instance.Money)
            {
                GameManager.instance.IncreaseStatistics(PriceSleep);
                sleep += IncSleep;
                RefreshUI();
                CheckingValueofStats();
            }
        }
    }
    private IEnumerator ReducingSleep()
    {
        while (loopSleep == true)
        {
            if (sleep <= 0)
            {
                sleep = 0;
                loopSleep = false;
                yield return new WaitUntil(() => loopSleep);
            }
            yield return new WaitForSeconds(TimeSleep);
            sleep -= AmountSleep;
            RefreshUI();
        }
    }


}
