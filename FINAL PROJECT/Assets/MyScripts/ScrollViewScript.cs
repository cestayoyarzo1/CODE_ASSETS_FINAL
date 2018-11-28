using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScript : MonoBehaviour
{
    public List<GameObject> messagelist = new List<GameObject>();
    
    public int maxMessages = 30;

    public GameObject panel;
    public GameObject textObject;
    public Scrollbar verticalScroll;
    //public Toggle autoScroll;

    float timer = 0.0f;
    int counter = 0;

    bool autoscroll;

    void Start()
    {
        //autoScroll.isOn = false;
        autoscroll = true;
    }

    void Update()
    {
        if (timer > 1)
        {
            counter += (int)timer;
            GameObject newTextObject = Instantiate(textObject, panel.transform);
            newTextObject.GetComponent<Text>().text = counter.ToString() + " seconds have gone by";
            AddMessage(newTextObject);
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
    public void AddMessage(GameObject messageObject)
    {
        if (autoscroll)
        {
            verticalScroll.value = 0.0f;
        }
        else if (!autoscroll)
        {
            verticalScroll.value = Mathf.Min(1.0f, verticalScroll.value + 1.0f / maxMessages);
        }

        messagelist.Add(messageObject);
        if (messagelist.Count >= maxMessages)
        {
            Destroy(messagelist[0].gameObject);
            messagelist.Remove(messagelist[0]);
        }
    }

    public void AutoScroll()
    {
        //verticalScroll.value = 0;
        autoscroll = true;
    }
}
