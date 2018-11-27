using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    Quest crownQuest;
    [SerializeField]
    GameObject questPanel;
    void Start()
    {

    }
	void Update ()
    {
		
	}

    public void StartCrownQuest()
    {
        crownQuest.Name = "Recover the Crown";
        crownQuest.Messages = new List<string>();
        crownQuest.Messages.Add("These mercenaries have stolen my Crown. " +
                                "They are unaware of the true powers it holds, and I cannot let it go. " +
                                "Would you help me find it?");
        crownQuest.Messages.Add("Thank you my friend, please go and kill Mercenary Zolriks until you find who has the crown. " +
                                "TI promise I will help you later if you help me. Please hurry up, before they sell it...");

        crownQuest.Messages.Add("Have you found the crown yet? " +
                                "Please don't waste time and hurry up");

        crownQuest.Messages.Add("Thank you my friend. Please take this letter of recomendation " +
                                "and come back to me if you need any help with anything. " +
                                "I am not sure I will still be here but you sure can find me around. Take care of yourself! ");
    }
}
