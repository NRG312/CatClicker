using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatingSoapBubbles : MonoBehaviour, IPointerDownHandler
{
    public GameObject SoapPrefab;
    public GameObject Bubbles;
    public List<GameObject> bubbles = new List<GameObject>();

    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(SoapPrefab, GameObject.Find("CatImageUI").transform);
    }


    float time;
    public void CreatingBubbles()
    {
        for (int i = 0; i < bubbles.Count; i++)
        {
            if (bubbles[i] == null)
            {
                bubbles.RemoveAt(i);
            }
        }
        if (bubbles.Count < 6)
        {
            time += Time.deltaTime;
        }
        if (time >= 0.6)
        {
            Vector2 CreateRandomBubbles = new Vector2(Random.Range(459, 700), Random.Range(1117, 1650));
            GameObject bubble = Instantiate(Bubbles, CreateRandomBubbles, Quaternion.identity, GameObject.Find("CatImageUI").transform);
            bubbles.Add(bubble);
            time = 0;
        }
        
    }
}
