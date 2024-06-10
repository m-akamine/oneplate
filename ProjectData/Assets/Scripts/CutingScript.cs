using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class CutingScript : MonoBehaviour
{
    //GameObject FoodObj;
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

        if (otherObjTag == "CuttingBoard")
        {
            CookingSwitch = true;
        }

        if (CookingSwitch == true && Count >= 0)
        {
            CookingTimer = CookingTimer - Time.deltaTime;

            if (Count <= 0)
            {
                CookingSwitch = false;
                Invoke("OnDestroy",1.0f);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        otherObjTag = other.tag;
        otherObj = other.GetComponent<Transform>();
        if (otherObjTag == "CuttingBoard")
        {
            Invoke("CutEnter", 0.5f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        otherObjTag = "";
    }

    public void CutEnter()
    {
        this.gameObject.transform.position = new Vector3(otherObj.position.x, otherObj.position.y + 0.2f, otherObj.position.z);
    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
