using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanelScript : MonoBehaviour
{
    [SerializeField]
    public Text title, body;
    [SerializeField]
    GameObject accept, cancel;

	void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void LoadTitle(string _title)
    {
        title.text = _title;
    }

    public void LoadBody(string _body)
    {
        body.text = _body;
    }


}
