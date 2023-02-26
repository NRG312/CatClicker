using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swapping : MonoBehaviour
{
    //Parameters rooms
    [SerializeField]private Canvas LivingRoom;
    private Image LivingRoomImage;
    [Header("Toilet Interface")]
    [SerializeField]private Canvas Toilet;
    private Image ToiletImage;
    [Header("Kitchen Interface")]
    [SerializeField]private Canvas Kitchen;
    private Image KitchenImage;

    //On click Buttons left & right
    private bool SwapRight;
    private bool SwapLeft;

    //Animators Images
    private Animator LivingRoomAnim;
    private Animator ToiletAnim;
    private Animator KitchenAnim;

    //Timer Parameters
    float time = 1f;

    private void Start()
    {
        LivingRoomImage = LivingRoom.GetComponentInChildren<Image>();
        ToiletImage = Toilet.GetComponentInChildren<Image>();
        KitchenImage = Kitchen.GetComponentInChildren<Image>();

        LivingRoomAnim = LivingRoom.GetComponentInChildren<Animator>();
        ToiletAnim = Toilet.GetComponentInChildren<Animator>();
        KitchenAnim = Kitchen.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (LivingRoomImage.enabled == false)
        {
            if (SwapRight)
            {
                LivingRoomAnim.SetTrigger("RightOff");

                LivingRoom.enabled = false;

                Toilet.sortingOrder = 0;
                Kitchen.sortingOrder = -1;
                LivingRoom.sortingOrder = -2;
            }
            if (SwapLeft)
            {
                LivingRoomAnim.SetTrigger("LeftOff");

                LivingRoom.enabled = false;

                Kitchen.sortingOrder = 0;
                Toilet.sortingOrder = -1;
                LivingRoom.sortingOrder = -2;
            }

        }
        if (ToiletImage.enabled == false)
        {
            if (SwapRight)
            {
                ToiletAnim.SetTrigger("RightOff");

                Toilet.enabled = false;
                
                Kitchen.sortingOrder = 0;
                LivingRoom.sortingOrder = -1;
                Toilet.sortingOrder = -2;
            }
            if (SwapLeft)
            {
                ToiletAnim.SetTrigger("LeftOff");

                Toilet.enabled = false;
                
                LivingRoom.sortingOrder = 0;
                Kitchen.sortingOrder = -1;
                Toilet.sortingOrder = -2;
            }
        }
        if (KitchenImage.enabled == false)
        {
            if (SwapRight)
            {
                KitchenAnim.SetTrigger("RightOff");

                Kitchen.enabled = false;

                LivingRoom.sortingOrder = 0;
                Toilet.sortingOrder = -1;
                Kitchen.sortingOrder = -2;
            }
            if (SwapLeft)
            {
                KitchenAnim.SetTrigger("LeftOff");

                Kitchen.enabled = false;

                Toilet.sortingOrder = 0;
                LivingRoom.sortingOrder = -1;
                Kitchen.sortingOrder = -2;
            }
        }
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        SwapRight = false;
        SwapLeft = false;
    }



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
            }
            else if (Toilet.enabled == true)
            {
                ToiletAnim.SetTrigger("Right");
                Kitchen.enabled = true;

                SwapRight = true;
            }
            else if (Kitchen.enabled == true)
            {
                KitchenAnim.SetTrigger("Right");
                LivingRoom.enabled = true;

                SwapRight = true;
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
            }
            else if (Kitchen.enabled == true)
            {
                KitchenAnim.SetTrigger("Left");
                Toilet.enabled = true;

                SwapLeft = true;
            }
            else if (Toilet.enabled == true)
            {
                ToiletAnim.SetTrigger("Left");
                LivingRoom.enabled = true;

                SwapLeft = true;
            }
        }
        
    }
}
