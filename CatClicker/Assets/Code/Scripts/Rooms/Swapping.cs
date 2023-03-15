using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swapping : MonoBehaviour
{
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

    //Animators Images
    private Animator LivingRoomAnim;
    private Animator ToiletAnim;
    private Animator KitchenAnim;
    //Animator Items Interface Kitchen
    private Animator BowlSwap;
    //Animator Items Interface toilet
    private Animator Shower;
    //Timer Parameters
    float time = 0.5f;

    private void Start()
    {
        Arrowleft.onClick.AddListener(ArrowLeft);
        Arrowright.onClick.AddListener(ArrowRight);


        //Searching Images
        LivingRoomImage = LivingRoom.GetComponentInChildren<Image>();
        ToiletImage = Toilet.GetComponentInChildren<Image>();
        KitchenImage = Kitchen.GetComponentInChildren<Image>();
        //Seraching Animator for rooms
        LivingRoomAnim = LivingRoom.GetComponentInChildren<Animator>();
        ToiletAnim = Toilet.GetComponentInChildren<Animator>();
        KitchenAnim = Kitchen.GetComponentInChildren<Animator>();
        //Seraching Animators for interface items in Kitchen
        BowlSwap = Kitchen.transform.Find("Bowl").GetComponent<Animator>();
        //Seraching Animators for interface items in Toilet
        Shower = GameObject.Find("InterfaceToilet").transform.Find("ShowerBackGround").GetComponent<Animator>();
    }
    //Checking for turn off Triggers && Changing sort orders
    private void Update()
    {
        if (SwapLeft == false)
        {
            if (LivingRoomImage.enabled == false)
            {
                if (SwapLeft == false)
                {
                    LivingRoomAnim.SetTrigger("LeftOff");

                    LivingRoom.enabled = false;

                    GameManager.instance.CanClickOnCat = false;

                    Kitchen.sortingOrder = 0;
                    Toilet.sortingOrder = -1;
                    LivingRoom.sortingOrder = -2;
                }

            }
            if (ToiletImage.enabled == false)
            {
                if (SwapLeft == false)
                {
                    ToiletAnim.SetTrigger("LeftOff");
                    Shower.SetTrigger("LeftOff");

                    Toilet.enabled = false;

                    GameManager.instance.CanClickOnCat = true;

                    LivingRoom.sortingOrder = 0;
                    Kitchen.sortingOrder = -1;
                    Toilet.sortingOrder = -2;
                }
            }
            if (KitchenImage.enabled == false)
            {
                if (SwapLeft == false)
                {
                    KitchenAnim.SetTrigger("LeftOff");
                    BowlSwap.SetTrigger("LeftOff");
                    Kitchen.enabled = false;

                    GameManager.instance.CanClickOnCat = false;

                    Toilet.sortingOrder = 0;
                    LivingRoom.sortingOrder = -1;
                    Kitchen.sortingOrder = -2;
                }
            }
        }
        if (SwapRight == false)
        {
            if (LivingRoomImage.enabled == false)
            {
                if (SwapRight == false)
                {
                    LivingRoomAnim.SetTrigger("RightOff");

                    LivingRoom.enabled = false;

                    GameManager.instance.CanClickOnCat = false;

                    Toilet.sortingOrder = 0;
                    Kitchen.sortingOrder = -1;
                    LivingRoom.sortingOrder = -2;
                }
            }
            if (ToiletImage.enabled == false)
            {
                if (SwapRight == false)
                {
                    ToiletAnim.SetTrigger("RightOff");
                    Shower.SetTrigger("RightOff");

                    Toilet.enabled = false;

                    GameManager.instance.CanClickOnCat = false;

                    Kitchen.sortingOrder = 0;
                    LivingRoom.sortingOrder = -1;
                    Toilet.sortingOrder = -2;
                }
            }
            if (KitchenImage.enabled == false)
            {
                if (SwapRight == false)
                {
                    KitchenAnim.SetTrigger("RightOff");
                    BowlSwap.SetTrigger("RightOff");

                    Kitchen.enabled = false;

                    GameManager.instance.CanClickOnCat = true;

                    LivingRoom.sortingOrder = 0;
                    Toilet.sortingOrder = -1;
                    Kitchen.sortingOrder = -2;
                }
            }
        }
    }
    //Waiting for next swap
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        SwapRight = false;
        SwapLeft = false;
    }


    //Swapping
    public void ArrowRight()
    {
        if (SwapRight == false)
        {
            StartCoroutine(Timer());

            if (LivingRoom.enabled == true)
            {
                LivingRoomAnim.SetTrigger("Right");
                Toilet.enabled = true;

                SwapRight = true;
                SwapLeft = true;
            }
            else if (Toilet.enabled == true)
            {
                ToiletAnim.SetTrigger("Right");
                Shower.SetTrigger("Right");
                Kitchen.enabled = true;

                SwapRight = true;
                SwapLeft = true;
            }
            else if (Kitchen.enabled == true)
            {
                KitchenAnim.SetTrigger("Right");
                BowlSwap.SetTrigger("Right");
                LivingRoom.enabled = true;

                SwapRight = true;
                SwapLeft = true;
            }
            
        }
    }
    public void ArrowLeft()
    {
        if (SwapLeft == false)
        {
            StartCoroutine(Timer());

            if (LivingRoom.enabled == true)
            {
                LivingRoomAnim.SetTrigger("Left");
                Kitchen.enabled = true;

                SwapLeft = true;
                SwapRight = true;
            }
            else if (Kitchen.enabled == true)
            {
                KitchenAnim.SetTrigger("Left");
                BowlSwap.SetTrigger("Left");
                Toilet.enabled = true;

                SwapLeft = true;
                SwapRight = true;
            }
            else if (Toilet.enabled == true)
            {
                ToiletAnim.SetTrigger("Left");
                Shower.SetTrigger("Left");
                LivingRoom.enabled = true;

                SwapLeft = true;
                SwapRight = true;
            }
        }
    }
}
