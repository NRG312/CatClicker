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

    [HideInInspector] public Transform parentafterDrag;
    [HideInInspector] public TMP_Text Amount;
    [HideInInspector] public int AmountItem = 1;


    private void Start()
    {
        CatImage = GameObject.Find("CatImage").GetComponent<Image>();
        Amount = GetComponentInChildren<TMP_Text>();
        Amount.text = AmountItem.ToString();
    }
    //Adding new parameters to itemFoodinEq
    public void SwitchParameters(Food newItem)
    {
        item = newItem;
        image = transform.Find("ImageFood").GetComponent<Image>();
        image.sprite = newItem.ImageFood;
    }
    public void AddAmount(int amount)
    {
        AmountItem += amount;
        Amount.text = AmountItem.ToString();
    }
    public void OnBeginDrag(PointerEventData data)
    {
        image.raycastTarget = false;
        parentafterDrag = transform.parent;
        transform.SetParent(GameObject.Find("CatImageUI").transform);
        GameObject.Find("FoodShopUI").GetComponent<Canvas>().enabled = false;
    }
    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData data)
    {
        image.raycastTarget = true;
        GameObject.Find("FoodShopUI").GetComponent<Canvas>().enabled = true;
        transform.SetParent(parentafterDrag);
    }
    
    public void OnDrop(PointerEventData data)
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.down);
        if (hit.collider.CompareTag("Cat"))
        {
            if (FunctionStatistics.instance.hunger < 100)
            {
                if (AmountItem > 1)
                {
                    FunctionStatistics.instance.HungerFunction(item);
                    AmountItem -= 1;
                    Amount.text = AmountItem.ToString();
                    transform.SetParent(parentafterDrag);
                }
                else if(AmountItem == 1)
                {
                    FunctionStatistics.instance.HungerFunction(item);
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            transform.SetParent(parentafterDrag);
        }
        
    }
    
}
