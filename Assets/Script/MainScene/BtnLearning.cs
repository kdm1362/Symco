using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnLearning : MonoBehaviour
{
    public void onClickBtn()
    {
        SceneManager.LoadScene("LearningMenu");
    }
}
