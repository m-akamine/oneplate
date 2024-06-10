using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GetFoodScript : MonoBehaviour
{
    public GameObject CarrotPrefab;
    public GameObject MeatPrefab;
    public Camera NowCam;
    string HitTag;

    bool CreateObjSW;

    bool isMouseBtn = false;

    public static Vector3 WorldPointToScreenPoint(Vector3 targetPos, Camera targetCamera)
    {
        return targetCamera.WorldToScreenPoint(targetPos);
    }
    void Start()
    {

    }

    void Update()
    {
        CreateObjSW = false;
        Ray GetFoodRay = NowCam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            isMouseBtn = true;
            CreateObjSW = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseBtn = false;
        }

        if (isMouseBtn == true)
        {
            Debug.DrawRay(GetFoodRay.origin, GetFoodRay.direction * 100, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(GetFoodRay, out hit))
            {
                HitTag = hit.collider.gameObject.tag;
                if(HitTag == "CarrotBucket" && CreateObjSW == true)
                {
                    Instantiate(CarrotPrefab);
                }
                
                if (HitTag == "Refrigerator" && CreateObjSW == true)
                {
                    Instantiate(MeatPrefab);
                }
            }
        }
        else
        {
            HitTag = "";
        }
    }
}
