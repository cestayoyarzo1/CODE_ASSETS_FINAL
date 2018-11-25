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
    GameObject panelTarget;


    void Start ()
    {
        //Text[] panelFill = GetComponentsInChildren<Text>();
        //print("Text contains " + panelFill.Length);
        //name = panelFill[0];
        //level = panelFill[1];
    }
	

	void Update ()
    {
        if(panel.activeSelf)
        {
            UpdateHealth();
        }
    }

    public void ActivateTargetPanel(GameObject target)
    {
        panelTarget = target;
        Stats tempStats = panelTarget.GetComponent<StatsController>().GetStats();
        name.text = tempStats.Name;
        level.text = "Level " + tempStats.Level.ToString();
        targetHealthBar.fillAmount = tempStats.Health / tempStats.MaxHP;
        panel.SetActive(true);
    }

    public void DeactivateTargetPanel()
    {
        panel.SetActive(false);
    }

    public void UpdateHealth()
    {
        Stats tempStats = panelTarget.GetComponent<StatsController>().GetStats();
        targetHealthBar.fillAmount = tempStats.Health / tempStats.MaxHP;
    }

}
