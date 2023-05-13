using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationsManagerCat : MonoBehaviour
{
    public static AnimationsManagerCat instance;

    private const string EYES__TRIG = "Eyes";
    private const string TAIL__TRIG = "Tail";
    private const string EARS__TRIG = "Ears";


    public AnimatorOverrideController onEating;
    public AnimatorOverrideController onClick;

    private void Start()
    {
        instance = this;
    }
    public void ChangeAnimationClipOnClick(AnimationClip Clip,string type)
    {
        if (type == "Ears")
        {
            onClick["EarsAnimation"] = Clip;
        }
    }
    public void AnimationOnClickToGrowthMoney()
    {
        GameObject.Find("Eyes,Blush,Nose").GetComponent<Animator>().runtimeAnimatorController = onClick;
        GameObject.Find("Tail").GetComponent<Animator>().runtimeAnimatorController = onClick;
        GameObject.Find("Ears").GetComponent<Animator>().runtimeAnimatorController = onClick;

        GameObject.Find("Eyes,Blush,Nose").GetComponent<Animator>().SetTrigger(EYES__TRIG);
        GameObject.Find("Tail").GetComponent<Animator>().SetTrigger(TAIL__TRIG);
        GameObject.Find("Ears").GetComponent<Animator>().SetTrigger(EARS__TRIG);
    }
    public void AnimationOnEatingCat()
    {

    }
    public void AnimationOnSleepingCat()
    {

    }
}
