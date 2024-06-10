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
            // 肉を焼く
            CookMeat();

            // 5秒後にチェックして焼きが終わっているか確認
            Timer timer = new Timer(CheckMeatStatus, null, 5000, Timeout.Infinite);

            Console.WriteLine("肉をつかみました。焼きが終わりましたか？");
            Console.ReadLine();
        }

        static void CookMeat()
        {
            // 肉を焼く処理
            Thread.Sleep(10000); // 例として10秒かかる焼き
            meatIsCooked = true;
        }

        static void CheckMeatStatus(object state)
        {
            if (meatIsCooked)
            {
                Console.WriteLine("焼きが終わりました！");
            }
            else
            {
                Console.WriteLine("焼きがまだです。もう少し待ってください。");
            }
        }
    }
}