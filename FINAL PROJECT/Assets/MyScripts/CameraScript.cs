using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform character, centerPoint;
    private float mouseX, mouseY;

    public float mouseSensitivity = 10f;
    public float zoom;
    public float zoomSpeed = 2f;
    private float zoomMin = -2f;
    private float zoomMax = -50f;
    public float smoothSpeed;
    public float distance;
    Vector3 translation;
    Vector3 rotation;
    void Start ()
    {
        zoom = -5f;
        distance = 5f;
        smoothSpeed = 5f;
    }
	
	void Update ()
    {
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        if (zoom > zoomMin)
        {
            zoom = zoomMin;
        }

        if (zoom < zoomMax)
        {
            zoom = zoomMax;
        }
        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += -Input.GetAxis("Mouse Y");

        }
        centerPoint.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        mouseY = Mathf.Clamp(mouseY, -30f, 30f);
        transform.localPosition = new Vector3(0, 2, zoom);
        translation = character.position - centerPoint.position;
        translation.y += 3;
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(character.position, centerPoint.position) > 3)
        {
            centerPoint.position += Time.deltaTime * translation;

        }
    }
}
