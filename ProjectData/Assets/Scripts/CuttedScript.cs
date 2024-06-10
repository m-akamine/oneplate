using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttedScript : MonoBehaviour
{
    string otherObjTag;
    Transform otherObj;
    public CutingScript cutingScript;

    float Timer = 10;
    int Count = 10;
    

    bool CuttingSwitch = false;
    bool CountSwitch = false;

    public GameObject CuttedCarrotPrefab;

    void Update()
    {
        if (CountSwitch == true)
        {
            Count = cutingScript.Count;
            Timer = Count;

            if (CuttingSwitch == false)
            {
                if (otherObjTag == "Carrot")
                {
                    if (Count == 0)
                    {
                        GameObject Cutting = Instantiate(CuttedCarrotPrefab);
                        Cutting.transform.position = new Vector3(otherObj.position.x, otherObj.position.y + 0.3f, otherObj.position.z);

                        CountSwitch = false;
                        CuttingSwitch = true;
                        Invoke("CuttingSwitcher", 3.0f);
                        Debug.Log(Cutting);
                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        otherObjTag = other.tag;
        if (otherObjTag == "Carrot")
        {
            CountSwitch = true;
            otherObj = other.GetComponent<Transform>();
            cutingScript = other.GetComponent<CutingScript>();
        }
    }

    public void CuttingSwitcher()
    {
        CuttingSwitch = false;
    }
}
