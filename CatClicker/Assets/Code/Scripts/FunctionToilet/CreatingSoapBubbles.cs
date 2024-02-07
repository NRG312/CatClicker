using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatingSoapBubbles : MonoBehaviour, IPointerDownHandler
{
    public GameObject SoapPrefab;
    public GameObject Bubbles;
    public List<GameObject> bubbles = new List<GameObject>();

    private GameObject corner1;
    private GameObject corner2;
    private GameObject corner3;

    private void Awake()
    {
        corner1 = GameObject.Find("Corner1");
        corner2 = GameObject.Find("Corner2");
        corner3 = GameObject.Find("Corner3");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(SoapPrefab, GameObject.Find("Cat").transform);
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
            Vector2 CreateRandomBubbles = new Vector2(Random.Range(corner1.transform.position.x, corner2.transform.position.x), Random.Range(corner1.transform.position.y,corner3.transform.position.y));

            GameObject bubble = Instantiate(Bubbles, CreateRandomBubbles, Quaternion.identity, GameObject.Find("Cat").transform);
            bubbles.Add(bubble);
            time = 0;
        }
        
    }

    public void DestroyBubbles()
    {
        GameObject[] Bubb  = GameObject.FindGameObjectsWithTag("Bubble");
        if (Bubb != null)
        {
            for (int i = 0; i < Bubb.Length; i++)
            {
                GameObject objToDestroy = Bubb[i];
                Destroy(objToDestroy);
            }
            
        }
    }
}
