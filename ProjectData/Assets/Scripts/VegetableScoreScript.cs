using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableScoreScript : MonoBehaviour
{
    public int Score;

    public GameObject OtherObj;
    public float OtherObjX;
    public float OtherObjY;
    public float OtherObjZ;

    public string OtherObjTag;
    public int ScoreTrue;

    void Start()
    {
        Score = 10;
        ScoreTrue = 1;
    }

    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        OtherObj = other.gameObject;
        OtherObjX = OtherObj.transform.position.x;
        OtherObjY = OtherObj.transform.position.y;
        OtherObjZ = OtherObj.transform.position.z;
        OtherObjTag = other.gameObject.tag;


        if (OtherObjTag == "Burn")
        {
            ScoreTrue = 2;
        }

        if (OtherObjTag == "Voile")
        {
            ScoreTrue = 3;
        }
    }
}
