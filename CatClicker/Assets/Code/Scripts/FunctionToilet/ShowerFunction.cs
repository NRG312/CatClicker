using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowerFunction : MonoBehaviour,IPointerMoveHandler
{
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
            FunctionStatistics.instance.HygieneFunction(IncreaseHygieneAfterBreakBubble);
        }
        if (hit.collider.CompareTag("Cat"))
        {
            FunctionStatistics.instance.HygieneFunction(IncreaseHygiene);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Input.mousePosition;
            FunctionStatistics.instance.loopHygiene = false;
        }
        else if (!Input.GetMouseButton(0))
        {
            Destroy(gameObject);
            FunctionStatistics.instance.loopHygiene = true;
        }
    }
}
