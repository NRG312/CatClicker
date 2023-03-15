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
    private TMP_Text NameFood;

    public Transform parentafterDrag;


    private void Start()
    {
        CatImage = GameObject.Find("CatImage").GetComponent<Image>();
    }
    //Adding new parameters to itemFoodinEq
    public void SwitchParameters(Food newItem)
    {
        item = newItem;
        //NameFood = transform.Find("NameFood").GetComponent<TMP_Text>();
        image = transform.Find("ImageFood").GetComponent<Image>();
        image.sprite = newItem.ImageFood;
        //NameFood.text = newItem.NameFood;
    }
    public void OnBeginDrag(PointerEventData data)
    {
        image.raycastTarget = false;
        parentafterDrag = transform.parent;
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData data)
    {
        image.raycastTarget = true;
       transform.SetParent(parentafterDrag);
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
        
    }
    
}
