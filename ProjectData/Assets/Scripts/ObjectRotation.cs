using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public changecamera changeCameraScript;
    public GameObject targetObject;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;
    public float zoomSpeed = 1;

    private Camera mainCamera;
    private Vector2 lastMousePosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (changeCameraScript.LookingSW == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                if (!reverse)
                {
                    //var x = (Input.mousePosition.y - lastMousePosition.y);
                    var y = (lastMousePosition.x - Input.mousePosition.x);

                    var newAngle = Vector3.zero;
                    //newAngle.x = x * rotationSpeed.x;
                    newAngle.y = y * rotationSpeed.y;

                    targetObject.transform.Rotate(newAngle);
                    lastMousePosition = Input.mousePosition;
                }
                else
                {
                    //var x = (lastMousePosition.y - Input.mousePosition.y);
                    var y = (Input.mousePosition.x - lastMousePosition.x);

                    var newAngle = Vector3.zero;
                    //newAngle.x = x * rotationSpeed.x;
                    newAngle.y = y * rotationSpeed.y;

                    targetObject.transform.Rotate(newAngle);
                    lastMousePosition = Input.mousePosition;
                }
            }
        }
    }
}