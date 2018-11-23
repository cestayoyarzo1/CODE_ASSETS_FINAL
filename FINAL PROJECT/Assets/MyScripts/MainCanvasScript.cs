using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasScript : MonoBehaviour
{
    [SerializeField]
    GameObject targetPanel;
    [SerializeField]
    Image targetHealthBar;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Text name, level;


    void Start ()
    {
        //Text[] panelFill = GetComponentsInChildren<Text>();
        //print("Text contains " + panelFill.Length);
        //name = panelFill[0];
        //level = panelFill[1];
    }
	

	void Update ()
    {
		
	}

    public void ActivateTargetPanel(GameObject target)
    {
        Stats tempStats = target.GetComponent<StatsController>().GetStats();
        name.text = tempStats.Name;
        level.text = "Level " + tempStats.Level.ToString();
        panel.SetActive(true);
    }

    public void DeactivateTargetPanel()
    {
        panel.SetActive(false);
    }
}
