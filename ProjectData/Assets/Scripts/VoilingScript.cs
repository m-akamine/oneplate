using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoilingScript : MonoBehaviour
{
    //public GameObject FoodObj;
    string otherObjTag;
    static Transform otherObj;
    public float CookingTimer;
    public int Count;
    Rigidbody ItemRG;

    bool CookingSwitch;

    void Start()
    {
        CookingSwitch = false;
    }

    void Update()
    {
        ItemRG = this.GetComponent<Rigidbody>();
        Count = (int)CookingTimer;

        if (otherObjTag == "Voile")
        {
            CookingSwitch = true;
        }

        if (CookingSwitch == true && Count >= 0)
        {
            CookingTimer = CookingTimer - Time.deltaTime;

            if (Count <= 0)
            {
                CookingSwitch = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        otherObjTag = other.tag;
        otherObj = other.GetComponent<Transform>();
        if (otherObjTag == "Voile")
        {
            Invoke("VoileEnter", 1.0f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        otherObjTag = "";
    }

    public void VoileEnter()
    {
        this.gameObject.transform.position = new Vector3(otherObj.position.x, otherObj.position.y + 0.4f, otherObj.position.z);
    }
}
