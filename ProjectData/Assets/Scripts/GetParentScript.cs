using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetParentScript : MonoBehaviour
{
    Transform ParentP;
    Transform ParentS;
    string otherObjTag;
    Rigidbody ItemRG;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            objTagReset();
        }

        ParentP = this.GetComponent<Transform>();

        if (otherObjTag == "Carrot")
        {
            ParentS.transform.parent = ParentP.transform;
        }

        if (otherObjTag == "CuttedCarrot")
        {
            ParentS.transform.parent = ParentP.transform;
        }

        if (otherObjTag == "Meat")
        {
            ParentS.transform.parent = ParentP.transform;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        ItemRG = other.GetComponent<Rigidbody>();
        otherObjTag = other.gameObject.tag;
        ParentS = other.transform;
    }

    public void OnTriggerExit(Collider other)
    {
        objTagReset();
        if (otherObjTag == "NONE")
        {
            Invoke("isKinematicT", 0.2f);
            ParentS.position = ParentS.position;
        }
    }

    public void isKinematicT()
    {
        ItemRG.isKinematic = true;
        ParentS.parent = null;
    }

    public void isKinematicF()
    {
        ItemRG.isKinematic = false;
    }

    public void objTagReset()
    {
        otherObjTag = "NONE";
    }
}
