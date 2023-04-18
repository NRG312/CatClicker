using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatingSoapBubbles : MonoBehaviour, IPointerDownHandler
{
    public GameObject SoapPrefab;
    public GameObject Bubbles;
    private List<GameObject> bubbles = new List<GameObject>();

    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(SoapPrefab, transform);
    }


    float time;
    public void CreatingBubbles()
    {
        if (bubbles.Count < 6)
        {
            time += Time.deltaTime;
        }
        if (time >= 0.6)
        {
            Vector2 CreateRandomBubbles = new Vector2(Random.Range(335, 741), Random.Range(1117, 698));
            GameObject bubble = Instantiate(Bubbles, CreateRandomBubbles, Quaternion.identity, transform);
            bubbles.Add(bubble);
            time = 0;
        }
        
    }
}
