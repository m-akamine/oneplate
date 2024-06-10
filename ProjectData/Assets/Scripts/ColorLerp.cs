using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    // Start is called before the first frame update
    [System.NonSerialized]
    public float Thickness;
    [System.NonSerialized]
    public float GrillLevel;
    public float FlyingPan;
    void Start()
    {
    }

    public void SetUpGrill()
    {
        burnTime = CalclateBurnTime(Thickness);
        Debug.LogFormat("BurnTime:{0}", burnTime);
        currentTime = 0.0f;

        Transform meshTransform = transform.Find("left side");
        if (meshTransform == null)
        {
              
            
            meshTransform = transform.Find("steak");
        }

        materials = meshTransform.GetComponent<MeshRenderer>().materials;
    }

    public void OnGriling()
    {

        currentTime += Time.deltaTime;

        float sigmoid = Sigmoid.GetValueClamp01(currentTime / burnTime);
        Color oritinColor = (sigmoid < 0.5f) ? startColor : brownColor;
        Color toColor = (sigmoid < 0.5f) ? brownColor : endColor;
        float ratio = (sigmoid < 0.5f) ? (sigmoid * 2.0f) : ((sigmoid - 0.5f) * 2.0f);

        foreach (var material in materials)
        {
            material.color = Color.Lerp(oritinColor, toColor, ratio);
        }

        GrillLevel = sigmoid;
    }

    public void OnExitGrill()
    {
    }

    float CalclateBurnTime(float thicness)
    {
        float burnTime = 0.5f + (1.0f - thicness) * 2.0f;
        return burnTime;
    }

    Material[] materials;
    readonly Color startColor = Color.white;
    readonly Color brownColor = new Color(176.0f / 256.0f, 113.0f / 256.0f, 87.0f / 256.0f);
    readonly Color endColor = new Color(10.0f / 256.0f, 5.0f / 256.0f, 0.0f);
    float burnTime;
    float currentTime = 0.0f;


}
