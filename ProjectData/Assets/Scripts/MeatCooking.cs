using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MeatCooking : MonoBehaviour
{
    public float cookingTime = 0.0f; // 焼く時間
    public float maxCookingTime = 10.0f; // 最大焼き時間
    public Color rawColor = Color.red; // 生の肉の色
    public Color cookedColor = Color.gray; // 焼き上がった肉の色

    private Renderer meatRenderer;
    private bool isCooked = false;
    private bool gameStarted = false;
    private bool isCooking;
    public float cookPercentage;
    string OtherObjTag;

    void Start()
    {
        meatRenderer = GetComponent<Renderer>();
        meatRenderer.material.color = rawColor; // 最初は生の肉の色
        isCooking = false;
    }
   
    void Update()
    {
        if (isCooking == true)
        {
            cookingTime += Time.deltaTime;
            //Debug.Log(cookingTime);
            //Debug.Log(maxCookingTime);

            if (OtherObjTag == "Untagged")
            {
                CookMeat();
            }
            // 最大焼き時間に達したら焼き上げる
            if (cookingTime >= maxCookingTime)
            {
                CookMeat();
            }

            // 肉の焼き加減を更新
            UpdateCookingState();
        }
    }

    void UpdateCookingState()
    {
        // 生の肉から焼き上がった肉への遷移を管理
        cookPercentage = cookingTime / maxCookingTime;
        meatRenderer.material.color = Color.Lerp(rawColor, cookedColor, cookPercentage);

    }

    void CookMeat()
    {
        isCooking = false;
        Debug.Log("肉が焼き上がりました！");
    }

    void OnCollisionEnter(Collision other)
    {
        OtherObjTag = other.collider.tag;

        if (OtherObjTag == "Burn" && isCooking == false)
        {
            // 衝突したオブジェクトが"CookingSurface"タグを持ち、かつまだ焼いていない場合
            //Debug.Log("肉が調理され始めました。");
            isCooking = true; // 調理を開始
        }
    }
}