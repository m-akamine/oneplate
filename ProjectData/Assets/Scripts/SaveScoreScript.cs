using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SaveScoreScript : MonoBehaviour
{
    public ScoreCheckScript scoreCheckScript;
    public int Score = 0;
    public int TotalVgScore = 0;
    public int TotalStScore = 0;

    public TextMeshPro ReviewText;

    void Update()
    {
        ReviewText.text = "野菜:" + TotalVgScore + "\n" +
                          "肉:" + TotalStScore + "\n" +
                          "今回の評価点:" + Score;
    }

    //ScoreCheckからスコアが来る
    public void AddTotalScore(int TotalScore)
    {
        Score = TotalScore;
        //Debug.Log(Score);
    }

    public void AddVgScore(int VgScore)
    {
        TotalVgScore = VgScore;
        //Debug.Log(TotalVgScore);
    }

    public void AddStScore(int StScore)
    {
        TotalStScore = StScore;
        //Debug.Log(TotalStScore);
    }
}