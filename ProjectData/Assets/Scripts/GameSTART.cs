using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSTART : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Demo");
    }
}