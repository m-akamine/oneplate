using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Meat : MonoBehaviour
{
    class Program
    {
        static bool meatIsCooked = false;

        static void Main()
        {
            // �����Ă�
            CookMeat();

            // 5�b��Ƀ`�F�b�N���ďĂ����I����Ă��邩�m�F
            Timer timer = new Timer(CheckMeatStatus, null, 5000, Timeout.Infinite);

            Console.WriteLine("�������݂܂����B�Ă����I���܂������H");
            Console.ReadLine();
        }

        static void CookMeat()
        {
            // �����Ă�����
            Thread.Sleep(10000); // ��Ƃ���10�b������Ă�
            meatIsCooked = true;
        }

        static void CheckMeatStatus(object state)
        {
            if (meatIsCooked)
            {
                Console.WriteLine("�Ă����I���܂����I");
            }
            else
            {
                Console.WriteLine("�Ă����܂��ł��B���������҂��Ă��������B");
            }
        }
    }
}