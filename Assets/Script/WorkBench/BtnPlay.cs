using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlay : MonoBehaviour
{
    // TODO: 블루투스 혹은 아닐경우 시뮬레이션으로 가는 기능 구현 필요
    public void OnClick()
    {
        SceneManager.LoadScene("Simulation");
    }
}
