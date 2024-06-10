using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnedScript : MonoBehaviour
{
    string otherObjTag;
    Transform otherObj;
    public BurningScript burningScript;

    bool BurningSwitch = false;

    void Start()
    {

    }

    void Update()
    {
        if (BurningSwitch == false)
        {
            if (otherObjTag == "Meat")
            {
                otherObj.position = this.transform.position;
                BurningSwitcher();
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        otherObjTag = other.tag;
        if (otherObjTag == "Meat")
        {
            otherObj = other.GetComponent<Transform>();
            burningScript = other.GetComponent<BurningScript>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        otherObjTag = "";
        BurningSwitch = false;
    }

    void BurningSwitcher()
    {
        BurningSwitch = true;
    }
}
