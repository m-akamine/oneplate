using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheckScript : MonoBehaviour
{
    int VgScore;
    int TotalVgScore;

    int StScore;
    int StScoreAbs;

    public int TotalScore;
    int ScoreCheckCount;
    int StScoreCheckCount;

    public RecipeController recipeController;

    string OtherObjTag;
    public NormalScoreScript StScoreScript;
    public VegetableScoreScript VgScoreScript;

    bool ScoreCheckSwitch;
    bool StScoreCountSwitch;
    bool VgScoreCountSwitch;

    public SaveScoreScript saveScoreScript;
    void Start()
    {
        ScoreCheckCount = 0;
        StScoreCheckCount = 0;
    }
    void Update()
    {
        if (ScoreCheckSwitch == true)
        {
            if (StScoreCountSwitch == true)
            {
                StScoreCheckCount = StScoreCheckCount + 1;

                if (StScoreCheckCount == 1)
                {
                    TotalScore = TotalScore + StScore;
                }

                StScoreCountSwitch = false;
            }
            ScoreCheckSwitch = false;
            saveScoreScript.AddVgScore(TotalVgScore);
            if (TotalScore > 100)
            {
                TotalScore = 100;
            }
        }
        saveScoreScript.AddTotalScore(TotalScore);
        saveScoreScript.AddStScore(StScore);

        /*if (TotalScore != StScore + TotalVgScore)
        {
            Debug.Log(TotalScore);
        }*/
        //Debug.Log(ScoreCheckCount);
        //Debug.Log(TotalVgScore);
    }

    public void OnTriggerEnter(Collider other)
    {
        OtherObjTag = other.tag;
        ScoreCheckSwitch = true;

        if (OtherObjTag == "Meat")
        {
            StScoreScript = other.GetComponent<NormalScoreScript>();

            if (recipeController.StCount == 1)
            {
                StScoreAbs = Mathf.Abs(10 - (int)StScoreScript.Yakeguai);
                if (StScoreAbs > 70)
                {
                    StScoreAbs = 70;
                }

                StScore = Mathf.Abs(70 - StScoreAbs);
            }

            if (recipeController.StCount == 2)
            {
                StScoreAbs = Mathf.Abs(30 - (int)StScoreScript.Yakeguai);
                if (StScoreAbs > 70)
                {
                    StScoreAbs = 70;
                }

                StScore = Mathf.Abs(70 - StScoreAbs);
            }

            if (recipeController.StCount == 3)
            {
                StScoreAbs = Mathf.Abs(50 - (int)StScoreScript.Yakeguai);
                if (StScoreAbs > 70)
                {
                    StScoreAbs = 70;
                }

                StScore = Mathf.Abs(70 - StScoreAbs);
            }

            if (recipeController.StCount == 4)
            {
                StScoreAbs = Mathf.Abs(70 - (int)StScoreScript.Yakeguai);
                if (StScoreAbs > 70)
                {
                    StScoreAbs = 70;
                }

                StScore = Mathf.Abs(70 - StScoreAbs);
            }

            if (recipeController.StCount == 5)
            {
                StScoreAbs = Mathf.Abs(90 - (int)StScoreScript.Yakeguai);
                if (StScoreAbs > 70)
                {
                    StScoreAbs = 70;
                }

                StScore = Mathf.Abs(70 - StScoreAbs);
            }
            StScoreCountSwitch = true;
            //Debug.Log(StScore);
        }

        if (OtherObjTag == "CuttedCarrot")
        {
            VgScoreScript = other.GetComponent<VegetableScoreScript>();
            VgScore = VgScoreScript.Score;
            TotalVgScore = TotalVgScore + VgScore;
            VgScoreCountSwitch = true;
            ScoreCheckCount = ScoreCheckCount + 1;
            if (TotalVgScore <= 30)
            {
                if (ScoreCheckCount >= 1)
                {
                    TotalScore = TotalScore + VgScore;
                    ScoreCheckCount = 0;
                }
            }
            else
            {
                VgScore = 0;
                TotalVgScore = 30;
                Debug.Log("else");
            }
        }

        if (VgScoreScript.ScoreTrue == recipeController.VgCount)
        {
            VgScore = 30;
        }
    }
}