using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningScript : MonoBehaviour
{
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

        if (otherObjTag == "Burn")
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
        if (otherObjTag == "Burn")
        {
            Invoke("BurnEnter", 1.0f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        otherObjTag = "";
    }

    public void BurnEnter()
    {
        this.transform.position = new Vector3(otherObj.position.x, otherObj.position.y + 2.0f, otherObj.position.z);
    }
}
