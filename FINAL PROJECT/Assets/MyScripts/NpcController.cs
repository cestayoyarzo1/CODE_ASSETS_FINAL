using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{

	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadQuest(GameObject panel)
    {
        panel.GetComponent<QuestPanelScript>().title.text = QuestManager.data.CrownQuest.name;
        panel.GetComponent<QuestPanelScript>().body.text = QuestManager.data.CrownQuest.Messages[0];
    }

}
