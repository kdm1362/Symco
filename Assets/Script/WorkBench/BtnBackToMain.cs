using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnBackToMain : MonoBehaviour
{
    public void OnClick()
    {
        // TODO: 문제풀이인지 연습인지 확인 후 적절히 처리 할 것
        SceneManager.LoadScene("MainMenu");
    }
}
