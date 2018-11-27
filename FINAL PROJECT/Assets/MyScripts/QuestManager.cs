using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    GameObject questPanel;
    public Quest CrownQuest;
    public static QuestManager data;

    void Start()
    {
        data = this;
    }
	void Update ()
    {
		
	}

    public void StartCrownQuest()
    {
        CrownQuest.Name = "Recover the Crown";
        CrownQuest.Messages = new List<string>();
        CrownQuest.Messages.Add("These mercenaries have stolen my Crown. " +
                                "They are unaware of the true powers it holds, and I cannot let it go. " +
                                "Would you help me find it?");
        CrownQuest.Messages.Add("Thank you my friend, please go and kill Mercenary Zolriks until you find the crown and bring it back to me. " +
                                "I promise I will help you later if you help me. Please hurry up, before they sell it...");

        CrownQuest.Messages.Add("Have you found the crown yet? " +
                                "Please don't waste time and hurry up");

        CrownQuest.Messages.Add("Thank you my friend. Please take this letter of recomendation " +
                                "and come back to me if you need any help with anything. " +
                                "I am not sure I will still be here but you sure can find me around. Take care of yourself! ");

    }
    public GameObject OpenQuestPanel()
    {
        questPanel.SetActive(true);
        return questPanel;
    }
}
