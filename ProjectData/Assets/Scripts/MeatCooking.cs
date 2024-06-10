using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MeatCooking : MonoBehaviour
{
    public float cookingTime = 0.0f; // �Ă�����
    public float maxCookingTime = 10.0f; // �ő�Ă�����
    public Color rawColor = Color.red; // ���̓��̐F
    public Color cookedColor = Color.gray; // �Ă��オ�������̐F

    private Renderer meatRenderer;
    private bool isCooked = false;
    private bool gameStarted = false;
    private bool isCooking;
    public float cookPercentage;
    string OtherObjTag;

    void Start()
    {
        meatRenderer = GetComponent<Renderer>();
        meatRenderer.material.color = rawColor; // �ŏ��͐��̓��̐F
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
            // �ő�Ă����ԂɒB������Ă��グ��
            if (cookingTime >= maxCookingTime)
            {
                CookMeat();
            }

            // ���̏Ă��������X�V
            UpdateCookingState();
        }
    }

    void UpdateCookingState()
    {
        // ���̓�����Ă��オ�������ւ̑J�ڂ��Ǘ�
        cookPercentage = cookingTime / maxCookingTime;
        meatRenderer.material.color = Color.Lerp(rawColor, cookedColor, cookPercentage);

    }

    void CookMeat()
    {
        isCooking = false;
        Debug.Log("�����Ă��オ��܂����I");
    }

    void OnCollisionEnter(Collision other)
    {
        OtherObjTag = other.collider.tag;

        if (OtherObjTag == "Burn" && isCooking == false)
        {
            // �Փ˂����I�u�W�F�N�g��"CookingSurface"�^�O�������A���܂��Ă��Ă��Ȃ��ꍇ
            //Debug.Log("������������n�߂܂����B");
            isCooking = true; // �������J�n
        }
    }
}