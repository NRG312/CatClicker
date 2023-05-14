using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swapping : MonoBehaviour
{
    public static Swapping instance;

    [Header("Living Room Interface")]
    public Canvas LivingRoom;
    private Image LivingRoomImage;
    [Header("Toilet Interface")]
    public Canvas Toilet;
    private Image ToiletImage;
    [Header("Kitchen Interface")]
    public Canvas Kitchen;
    private Image KitchenImage;


    [Header("Arrows To Swap Rooms")]
    public Button Arrowright;
    public Button Arrowleft;

    //On click Buttons left & right
    private bool SwapRight;
    private bool SwapLeft;

    //Block Swap Bool
    [HideInInspector]public bool BlockSwap;

    

    private void Start()
    {
        instance = this;

        Arrowleft.onClick.AddListener(ArrowLeft);
        Arrowright.onClick.AddListener(ArrowRight);
    }


    //Swapping
    public void ArrowRight()
    {
        if (SwapRight == false && BlockSwap == false)
        {
            if (LivingRoom.enabled == true)
            {
                GameManager.instance.CanClickOnCat = false;
                Toilet.enabled = true;
                LivingRoom.enabled = false;
                Kitchen.enabled = false;
            }
            else if (Toilet.enabled == true)
            {
                GameManager.instance.CanClickOnCat = false;
                Kitchen.enabled = true;
                Toilet.enabled = false;
                LivingRoom.enabled = false;
            }
            else if (Kitchen.enabled == true)
            {
                GameManager.instance.CanClickOnCat = true;
                LivingRoom.enabled = true;
                Kitchen.enabled = false;
                Toilet.enabled = false;
            }
            
        }
    }
    public void ArrowLeft()
    {
        if (SwapLeft == false && BlockSwap == false)
        {
            if (LivingRoom.enabled == true)
            {
                GameManager.instance.CanClickOnCat = false;
                Kitchen.enabled = true;
                Toilet.enabled = false;
                LivingRoom.enabled = false;
            }
            else if (Kitchen.enabled == true)
            {
                GameManager.instance.CanClickOnCat = false;
                Toilet.enabled = true;
                Kitchen.enabled = false;
                LivingRoom.enabled = false;
            }
            else if (Toilet.enabled == true)
            {
                GameManager.instance.CanClickOnCat = true;
                LivingRoom.enabled = true;
                Kitchen.enabled = false;
                Toilet.enabled = false;
            }
        }
    }
}
