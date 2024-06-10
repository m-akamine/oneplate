using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiledScript : MonoBehaviour
{
    string otherObjTag;
    Transform otherObj;
    public VoilingScript voilingScript;

    float Timer = 10;
    int Count = 10;


    bool VoilingSwitch = false;
    bool CountSwitch = false;

    void Start()
    {

    }

    void Update()
    {
        if (CountSwitch == true)
        {
            Count = voilingScript.Count;
            Timer = Count;

            if (VoilingSwitch == false)
            {
                if (otherObjTag == "CuttedCarrot")
                {
                    if (Count == 0)
                    {
                        otherObj.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.3f, this.transform.position.z);

                        CountSwitch = false;
                        VoilingSwitch = true;
                        Invoke("VoilingSwitcher", 3.0f);
                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        otherObjTag = other.tag;
        if (otherObjTag == "CuttedCarrot")
        {
            otherObj = other.GetComponent<Transform>();
            voilingScript = other.GetComponent<VoilingScript>();
            Debug.Log(otherObjTag);
        }
    }

    public void VoilingSwitcher()
    {
        VoilingSwitch = false;
    }
}
