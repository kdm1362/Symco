using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugAddCat : MonoBehaviour
{
    [SerializeField]
    GameObject pi;

    public void onClickBtn()
    {
        DrawGraph dg = pi.GetComponent<DrawGraph>();
        dg.addCat(0.2f, Color.blue);
    }
}
