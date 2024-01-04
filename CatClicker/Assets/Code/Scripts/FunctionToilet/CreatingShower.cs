using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatingShower : MonoBehaviour,IPointerDownHandler
{
    public GameObject Shower;

    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(Shower, GameObject.Find("Cat").transform);
    }

    
}
