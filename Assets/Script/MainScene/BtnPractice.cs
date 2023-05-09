using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPractice : MonoBehaviour
{
    public void onClickBtn()
    {
        SceneManager.LoadScene("WorkBench");
    }
}
