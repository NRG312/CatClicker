using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationsManagerCat : MonoBehaviour
{
    private const string EYES__TRIG = "Eyes";
    private const string TAIL__TRIG = "Tail";
    private const string EARS__TRIG = "Ears";


    public RuntimeAnimatorController Onclick;
    public RuntimeAnimatorController OnEating;
    public RuntimeAnimatorController OnSleeping;
    public void AnimationOnClickToGrowthMoney()
    {
        GameObject.Find("Eyes,Blush,Nose").GetComponent<Animator>().runtimeAnimatorController = Onclick;
        GameObject.Find("Tail").GetComponent<Animator>().runtimeAnimatorController = Onclick;
        GameObject.Find("Ears").GetComponent<Animator>().runtimeAnimatorController = Onclick;

        GameObject.Find("Eyes,Blush,Nose").GetComponent<Animator>().SetTrigger(EYES__TRIG);
        GameObject.Find("Tail").GetComponent<Animator>().SetTrigger(TAIL__TRIG);
        GameObject.Find("Ears").GetComponent<Animator>().SetTrigger(EARS__TRIG);


        //Na przyszloœæ mo¿e sie przydac
        //GameObject.Find("Tail").GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Assets/Level/Animations/Cat/AnimationController/Gowno.controller") as RuntimeAnimatorController;
    }
    public void AnimationOnEatingCat()
    {

    }
    public void AnimationOnSleepingCat()
    {

    }
}
