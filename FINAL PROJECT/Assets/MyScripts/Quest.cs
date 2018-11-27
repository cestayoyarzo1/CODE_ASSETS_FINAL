using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct QuestFlow
{

}

public class Quest
{
    public string Name;

    public enum Status
    {
        NotStarted,
        Start,
        Follow,
        Incomplete,
        Finished
    }
    

    public Status questStatus;

    public QuestFlow MyProperty { get; set; }
    public string StartNPC { get; set; }
    public string Objective { get; set; }
    

    public string ItemToCollect { get; set; }

    public int QuantityToCollect { get; set; }

    public int Collected { get; set; }


    public List<string> Messages;
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
