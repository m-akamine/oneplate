using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigmoid : MonoBehaviour
{
    // Start is called before the first frame update
    public static float GetValue(float input)
    {
        return input / Mathf.Sqrt(1 + Mathf.Pow(input, 2.0f));
    }

    public static float GetValueClamp01(float clampedInput)
    {


        clampedInput = Mathf.Clamp01(clampedInput);
        float input = clampedInput - 0.5f;
        input *= (clampAbsValue / 0.5f);

        float output = GetValue(input) + 1.0f;
        output /= 2.0f;
        return output;
    }

    private static readonly float clampAbsValue = 6.0f;
}