using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowerFunction : MonoBehaviour,IPointerMoveHandler
{
    //musisz zrobic cos nowego ze swapping rooms bo to dziala beznadziejnie
    //animacje interfejsu w kiblu musisz wprowadzic kodem do swapping wtedy sie poruszaja nie rob osobnych animatorow!
    //zacznij robic UI do wszystkiego pokoje GUI itp. tylko musisz zaczekac az dadza dobre grafiki
    public int IncreaseHygiene;
    public int IncreaseHygieneAfterBreakBubble;
    public void OnPointerMove(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.down);
        GameObject target;
        if (hit.collider.CompareTag("Bubble"))
        {
            target = hit.transform.gameObject;
            Destroy(target);
            GameObject.Find("RoomsController").GetComponent<FunctionStatistics>().HygieneFunction(IncreaseHygieneAfterBreakBubble);
        }
        if (hit.collider.CompareTag("Cat"))
        {
            GameObject.Find("RoomsController").GetComponent<FunctionStatistics>().HygieneFunction(IncreaseHygiene);
        }
    }

    void Update()
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
