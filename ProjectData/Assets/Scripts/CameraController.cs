using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;
    public float MoveDis;
    public float sensitivity = 2.0f; // フリックの感度
    private float rotationY = 0.0f; // Y軸回転の角度

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x - MoveDis, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + MoveDis, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
    }
}
