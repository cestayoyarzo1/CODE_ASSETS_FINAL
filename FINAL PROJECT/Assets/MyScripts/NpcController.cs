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
        QuestManager.data.StartCrownQuest();
        panel.GetComponent<QuestPanelScript>().title.text = QuestManager.data.CrownQuest.Name;
        panel.GetComponent<QuestPanelScript>().body.text = QuestManager.data.CrownQuest.Messages[0];
    }

}
