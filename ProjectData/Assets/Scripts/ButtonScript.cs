using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void OnClick()
    {
        // ���C���V�[���ֈړ�
        SceneManager.LoadScene("Demo");
    }
}