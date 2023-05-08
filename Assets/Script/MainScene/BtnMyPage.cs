using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMyPage : MonoBehaviour
{
    public void onClickBtn()
    {
        SceneManager.LoadScene("MyPage");
    }
}
