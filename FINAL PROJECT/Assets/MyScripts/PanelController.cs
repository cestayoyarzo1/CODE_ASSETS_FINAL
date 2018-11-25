using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    //Mouse configuration
    [SerializeField]
    Texture2D defaultMouse, attackTexture, questTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    [SerializeField]
    AudioClip openPanel, closePanel;
    AudioSource panelSound;


    private Ray ray;
    private RaycastHit hit;
    void Start ()
    {
        panelSound = GetComponentInChildren<AudioSource>();
        Cursor.SetCursor(defaultMouse, hotSpot, cursorMode);
    }
	
	void Update ()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500))
        {
            if (hit.transform.root.CompareTag("Enemy"))
            {
                Cursor.SetCursor(attackTexture, hotSpot, cursorMode);
            }
            else if (hit.transform.root.CompareTag("NPC"))
            {
                Cursor.SetCursor(questTexture, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(defaultMouse, hotSpot, cursorMode);
            }
        }
    }

    public void ActivatePanel(GameObject panel)
    {
        panelSound.PlayOneShot(openPanel);
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panelSound.PlayOneShot(closePanel);
        panel.SetActive(false);
    }

    public void TogglePanel(GameObject panel)
    {
        if(panel.activeSelf)
        {
            ClosePanel(panel);
        }
        else
        {
            ActivatePanel(panel);
        }
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(defaultMouse, hotSpot, cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(defaultMouse, hotSpot, cursorMode);
    }
}
