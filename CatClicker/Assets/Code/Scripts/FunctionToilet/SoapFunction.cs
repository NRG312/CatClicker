using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoapFunction : MonoBehaviour,IPointerMoveHandler
{
    public void OnPointerMove(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.down);
        GameObject soap = GameObject.Find("Soap");
        if (hit.collider.CompareTag("Cat"))
        {
            soap.GetComponent < CreatingSoapBubbles>().CreatingBubbles();
        }
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Input.mousePosition;
        }
        else if (!Input.GetMouseButton(0))
        {
            Destroy(gameObject);
        }
    }
    

}
