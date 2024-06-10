using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GripItemScript : MonoBehaviour
{
    public changecamera changeCameraScript;

    public GameObject Tray;

    public Rigidbody ItemRG;
    public GUIStyle textStyle;
    public Transform Item;
    public Camera NowCam;
    string HitName;
    string HitTag;

    bool isMouseBtn = false;
    bool isKinematicSwitch;

    float ItemPosY;
    float ItemPosZ;

    float ItemScalePlus;

    Vector3 screen_point;
    Vector3 targetPos;
    Vector3 mousePos;
    Vector3 world_position;

    RaycastHit hit;
    bool ItemSC;

    public static Vector3 WorldPointToScreenPoint(Vector3 targetPos, Camera targetCamera)
    {
        return targetCamera.WorldToScreenPoint(targetPos);
    }

    void Start()
    {
        ItemSC = false;
    }

    void Update()
    {
        Ray testRayCam = NowCam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            isMouseBtn = true;
            ItemSC = true;
            Debug.Log(HitName);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseBtn = false;
            isKinematicSwitch = true;

            if (hit.collider)
            {
                if (isKinematicSwitch == true)
                {
                    ItemRG.useGravity = true;
                    Item.localScale = new Vector3(Item.localScale.x - ItemScalePlus, Item.localScale.y - ItemScalePlus, Item.localScale.z - ItemScalePlus);
                    Invoke("ItemRelease", 1.0f);
                    isKinematicSwitch = false;
                }
            }

            if ((Item.position.x >= (Tray.transform.position.x - 0.455f)))
            {
                if (Item.position.x <= (Tray.transform.position.x + 0.3f))
                {
                    if (Item.position.z <= 0.58f)
                    {
                        Item.position = new Vector3(Tray.transform.position.x, Tray.transform.position.y + 0.2f, Tray.transform.position.z);
                    }
                    Debug.Log(Tray.transform.position);
                }
            }
        }

        if (isMouseBtn == true)
        {
            Debug.DrawRay(testRayCam.origin, testRayCam.direction * 100, Color.red);

            if (Physics.Raycast(testRayCam, out hit))
            {
                HitName = hit.collider.gameObject.name;
                HitTag = hit.collider.gameObject.tag;

                if (HitTag == "Carrot" || HitTag == "Meat" || HitTag == "CuttedCarrot")
                {
                    Item = hit.collider.GetComponent<Transform>();
                    ItemRG = hit.collider.GetComponent<Rigidbody>();
                    ItemRG.velocity = Vector3.zero;

                    Invoke("ItemCatch", 0.2f);
                    ItemRG.useGravity = false;

                    screen_point = Input.mousePosition;
                    targetPos = NowCam.WorldToScreenPoint(Item.position);
                    //Debug.Log(NowCam.transform.position.x);
                    //Debug.Log(Input.mousePosition.x);
                    mousePos = new Vector3(NowCam.transform.position.x + Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.y / 250);

                    world_position = NowCam.ScreenToWorldPoint(mousePos);

                    Item.position = world_position;
                    ItemPosY = Item.position.y;
                    ItemPosZ = Item.position.z;
                    if (ItemPosZ >= 0.8f)
                    {
                        ItemPosZ = 0.8f;
                        Item.position = new Vector3(Item.position.x, Item.position.y, ItemPosZ);
                    }

                    if (ItemPosZ <= -0.55f)
                    {
                        if (ItemPosY <= 1.14f)
                        {
                            ItemPosY = 1.15f;
                            Item.position = new Vector3(Item.position.x, ItemPosY, Item.position.z);
                        }
                    }

                    if (ItemSC == true)
                    {
                        if (HitTag == "Carrot")
                        {
                            ItemScalePlus = 15;
                        }

                        if (HitTag == "CuttedCarrot")
                        {
                            ItemScalePlus = 1.5f;
                        }

                        if (HitTag == "Meat")
                        {
                            ItemScalePlus = 1;
                        }

                        Item.localScale = new Vector3(Item.localScale.x + ItemScalePlus, Item.localScale.y + ItemScalePlus, Item.localScale.z + ItemScalePlus);
                        ItemSC = false;
                    }
                }

                if (HitTag == "Bell")
                {
                    changeCameraScript.CamSW(true);
                }
            }
        }
        else if (isMouseBtn == false)
        {
            HitName = "";
            HitTag = "";
        }
    }

    void ItemRelease()
    {
        ItemRG.isKinematic = true;
    }

    void ItemCatch()
    {
        ItemRG.isKinematic = false;
    }
}