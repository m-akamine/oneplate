using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecamera : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject ReviewCam;

    public bool PlayerCamSW;
    public bool ReviewCamSW;

    public bool LookingSW;
    void Start()
    {
        PlayerCamSW = true;
        ReviewCamSW = false;
    }

    void Update()
    {
        if (PlayerCamSW == true && ReviewCamSW == false)
        {
            PlayerCam.SetActive(true);
            ReviewCam.SetActive(false);
        }

        if (PlayerCamSW == false && ReviewCamSW == true)
        {
            PlayerCam.SetActive(false);
            ReviewCam.SetActive(true);
        }
    }

    public void CamSW(bool CamSW)
    {
        if (CamSW == true)
        {
            ReviewCamSW = true;
            PlayerCamSW = false;

            LookingSW = true;
        }
    }
}