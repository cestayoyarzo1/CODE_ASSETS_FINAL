using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct QuestFlow
{

}

public class Quest : MonoBehaviour
{
    public string Name;

    public enum Status
    {
        NotStarted,
        Inprogress,
        Finished
    }

    public Status questStatus;

    public QuestFlow MyProperty { get; set; }
    public string StartNPC { get; set; }
    public string Objective { get; set; }
    

    public string ItemToCollect { get; set; }

    public int QuantityToCollect { get; set; }

    public int Collected { get; set; }

    public string StartMessage { get; set; }

    public string UncompletedMessage { get; set; }

    public string FinalMessage { get; set; }

    void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}

    public void AcceptQuest()
    {

    }
}
