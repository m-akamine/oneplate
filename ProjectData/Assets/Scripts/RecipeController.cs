using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class RecipeController : MonoBehaviour
{
    public string[] VEGETABLE_ORDER;
    public string[] STAKE_ORDER;

    public string VegetableOrder;
    public string VegetableText;

    public string StakeOrder;
    public string StakeText;

    public int VgCount;
    public int StCount;

    public TextMeshPro RecipeObj;
    string RecipeText;
    void Start()
    {
        //ランダムで取得する
        VgRecipe();
        StRecipe();

        //レシピを出力
        RecipeText = "野菜:" + VegetableText + "\n" + "肉の焼き具合:" + StakeText;
        RecipeObj.text = RecipeText;
    }

    public void VgRecipe()
    {
        VegetableOrder = VEGETABLE_ORDER.ElementAt(Random.Range(0, VEGETABLE_ORDER.Count()));

        if (VegetableOrder == "Raw")
        {
            VegetableText = "生";
            VgCount = 1;
        }

        if (VegetableOrder == "Burn")
        {
            VegetableText = "焼き";
            VgCount = 2;
        }

        if (VegetableOrder == "Voile")
        {
            VegetableText = "茹で";
            VgCount = 3;
        }
    }

    public void StRecipe()
    {
        StakeOrder = STAKE_ORDER.ElementAt(Random.Range(0, STAKE_ORDER.Count()));

        if (StakeOrder == "Raw")
        {
            StakeText = "生";
            StCount = 1;
        }

        if (StakeOrder == "Rare")
        {
            StakeText = "レア";
            StCount = 2;
        }

        if (StakeOrder == "Medium")
        {
            StakeText = "ミディアム";
            StCount = 3;
        }

        if (StakeOrder == "Welldone")
        {
            StakeText = "ウェルダン";
            StCount = 4;
        }

        if (StakeOrder == "Coal")
        {
            StakeText = "もはや炭";
            StCount = 5;
        }
    }
}