using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{

    [SerializeField]
    public string description;
    [SerializeField]
    Text descText;
    [SerializeField]
    GameObject panel;
    Button thisButton;
    PanelController controller;

	void Start ()
    {
        descText.text = description;
        thisButton = GetComponent<Button>();
        controller = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<PanelController>();
        thisButton.onClick.AddListener(ToggleView);

    }
	
	void Update ()
    {

	}

    void ToggleView()
    {
        controller.TogglePanel(panel);
        print("hello world");
    }
}
