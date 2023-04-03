using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemPrefab : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler,IDropHandler
{
    public Food item;
    public Image CatImage;
    private Image image;

    public Transform parentafterDrag;


    private void Start()
    {
        CatImage = GameObject.Find("CatImage").GetComponent<Image>();
    }
    //Adding new parameters to itemFoodinEq
    public void SwitchParameters(Food newItem)
    {
        item = newItem;
        image = transform.Find("ImageFood").GetComponent<Image>();
        image.sprite = newItem.ImageFood;
    }
    public void OnBeginDrag(PointerEventData data)
    {
        image.raycastTarget = false;
        parentafterDrag = transform.parent;
        transform.SetParent(transform.root);
        //GameObject.Find("FoodShopUI").GetComponent<Canvas>().sortingOrder = 0;
        //transform.position = Input.mousePosition;
    }
    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
        //GameObject.Find("FoodShopUI").GetComponent<Canvas>().sortingOrder = -4;
    }
    public void OnEndDrag(PointerEventData data)
    {
        image.raycastTarget = true;
       transform.SetParent(parentafterDrag);
        GameObject.Find("FoodShopUI").GetComponent<Canvas>().sortingOrder = 10;
    }
    
    public void OnDrop(PointerEventData data)
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.down);
        if (hit.collider.CompareTag("Cat"))
        {
            GameObject RoomContoller = GameObject.Find("RoomsController");
            if (RoomContoller.GetComponent<FunctionStatistics>().hunger < 100)
            {
                RoomContoller.GetComponent<FunctionStatistics>().HungerFunction(item);
                Destroy(gameObject);
            }
            else
            {
                transform.SetParent(parentafterDrag);
            }
        }
        else if(!hit.collider.CompareTag("Cat"))
        {
            transform.SetParent(parentafterDrag);
        }
        //GameObject.Find("FoodShopUI").GetComponent<Canvas>().sortingOrder = 10;
        
    }
    
}
