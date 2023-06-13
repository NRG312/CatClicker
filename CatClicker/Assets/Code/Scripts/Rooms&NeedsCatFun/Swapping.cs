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
    public Button arrowRight;
    public Button arrowLeft;

    //On click Buttons left & right
    private bool swapRight;
    private bool swapLeft;

    //Block Swap Bool
    [HideInInspector]public bool blockSwap;

    

    private void Start()
    {
        instance = this;

        arrowLeft.onClick.AddListener(ArrowLeft);
        arrowRight.onClick.AddListener(ArrowRight);
    }


    //Swapping
    public void ArrowRight()
    {
        if (swapRight == false && blockSwap == false)
        {
            if (LivingRoom.gameObject.activeInHierarchy)
            {
                GameManager.instance.CanClickOnCat = false;
                Toilet.gameObject.SetActive(true);
                LivingRoom.gameObject.SetActive(false);
                Kitchen.gameObject.SetActive(false);
            }
            else if (Toilet.gameObject.activeInHierarchy)
            {
                GameManager.instance.CanClickOnCat = false;
                Kitchen.gameObject.SetActive(true);
                Toilet.gameObject.SetActive(false);
                LivingRoom.gameObject.SetActive(false);
            }
            else if (Kitchen.gameObject.activeInHierarchy)
            {
                GameManager.instance.CanClickOnCat = true;
                LivingRoom.gameObject.SetActive(true);
                Kitchen.gameObject.SetActive(false);
                Toilet.gameObject.SetActive(false);
            }

        }
    }
    public void ArrowLeft()
    {
        if (swapLeft == false && blockSwap == false)
        {
            if (LivingRoom.gameObject.activeInHierarchy)
            {
                GameManager.instance.CanClickOnCat = false;
                Kitchen.gameObject.SetActive(true);
                Toilet.gameObject.SetActive(false);
                LivingRoom.gameObject.SetActive(false);
            }
            else if (Kitchen.gameObject.activeInHierarchy)
            {
                GameManager.instance.CanClickOnCat = false;
                Toilet.gameObject.SetActive(true);
                Kitchen.gameObject.SetActive(false);
                LivingRoom.gameObject.SetActive(false);
            }
            else if (Toilet.gameObject.activeInHierarchy)
            {
                GameManager.instance.CanClickOnCat = true;
                LivingRoom.gameObject.SetActive(true);
                Kitchen.gameObject.SetActive(false);
                Toilet.gameObject.SetActive(false);
            }
        }
    }
}
