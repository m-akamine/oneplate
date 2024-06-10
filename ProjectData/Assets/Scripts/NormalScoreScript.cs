using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalScoreScript : MonoBehaviour
{
    [System.NonSerialized]
    public float Thickness;
    [System.NonSerialized]
    public float GrillLevel;

    public int Score;
    public float Yakeguai;
    public MeatCooking meatCooking;

    bool BurnSwitch;
    string OtherObjTag;
    Vector3 OtherObjPos;

    public float Collar;
    void Start()
    {
        Yakeguai = 0.0f;
        BurnSwitch = false;
    }

    void Update()
    {
        meatCooking = this.GetComponent<MeatCooking>();
        Yakeguai = meatCooking.cookPercentage * 100;
        if (BurnSwitch == true)
        {
            
           


        } //Ç±Ç±Ç≈ÉXÉRÉAÇ∆èƒÇØãÔçáÇÃí≤êÆÇ¡ÇƒÇ¢Ç§Ç©çáëÃ
        if (Input.GetMouseButtonUp(0))
            {
                if (OtherObjTag == "Burn")
                {
                    BurnSwitch = true;
                    this.gameObject.transform.position = OtherObjPos;
                }
            }
        }
    }

   
