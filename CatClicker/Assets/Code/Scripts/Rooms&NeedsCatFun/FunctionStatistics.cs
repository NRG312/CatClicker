using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionStatistics : MonoBehaviour
{
    public static FunctionStatistics instance;
    [Header("StatisticsSlider")]
    [SerializeField] private Slider Hygiene;
    [SerializeField] private Slider WC;
    [SerializeField] private Slider Hunger;
    [SerializeField] private Slider Sleep;

    //Main Amounts for stats
    [HideInInspector] public int hygiene = 100;
    [HideInInspector] public int wc = 100;
    [HideInInspector] public int hunger = 100;
    [HideInInspector] public int sleep = 100;
    //bools for enumerators
    [HideInInspector]public bool loopHygiene = true;
    [HideInInspector]public bool loopWc = true;
    private bool loopHunger = true;
    [HideInInspector]public bool loopSleep = true;
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

    private void Start()
    {
        instance = this;

        Reducinghygiene = ReducingHygiene();
        Reducingwc = ReducingWC();
        Reducinghunger = ReducingHunger();
        Reducingsleep = ReducingSleep();

        StartCoroutine(Reducinghygiene);
        StartCoroutine(Reducingwc);
        StartCoroutine(Reducinghunger);
        StartCoroutine(Reducingsleep);
    }
    //Loading values from data
    public void LoadSavedStats(int Sleep,int Hunger,int Wc,int Hygiene)
    {
        hygiene = Hygiene;
        wc = Wc;
        hunger = Hunger;
        sleep = Sleep;
        RefreshUI();
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

    float _timekeeperHygiene;
    public void HygieneFunction(int Increase)
    {
        if (hygiene < 100) //pomysl potem nad tym zeby zrobic gladkie zwiekszanie higieny
        {
            _timekeeperHygiene += Time.deltaTime;
            if (_timekeeperHygiene >= 0.3f)
            {
                hygiene += Increase;
                RefreshUI();
                _timekeeperHygiene = 0;
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

    float _timeKeeperWc;
    public void WCFunction()
    {
        if (wc < 100)
        {
            loopWc = false;
            _timeKeeperWc += Time.deltaTime;

            if (_timeKeeperWc >= 0.2f)
            {
                wc += 1;
                RefreshUI();
                _timeKeeperWc = 0;
            }
            if (wc >= 100)
            {
                GameObject.Find("LitterBox").GetComponent<WcFunction>().EndRegeneration();
                CheckingValueofStats();
            }

        }
        else if (wc >= 100)
        {
            GameObject.Find("LitterBox").GetComponent<WcFunction>().EndRegeneration();
            CheckingValueofStats();
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
    

    public void HungerFunction(Food food)
    {
        hunger += food.ValueToIncrease;
        RefreshUI();
        CheckingValueofStats();
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

    float _timeKeeperSleep;
    public void SleepFunction()
    {
        if (sleep < 100)
        {
            loopSleep = false;
            _timeKeeperSleep += Time.deltaTime;

            if (_timeKeeperSleep >= 0.2f)
            {
                sleep += 1;
                RefreshUI();
                _timeKeeperSleep = 0;
            }
            if (sleep >= 100)
            {
                GameObject.Find("Beeding").GetComponent<SleepFunction>().EndRegeneration();
                CheckingValueofStats();
            }

        }
        else if (sleep >= 100)
        {
            GameObject.Find("Beeding").GetComponent<SleepFunction>().EndRegeneration();
            CheckingValueofStats();
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
