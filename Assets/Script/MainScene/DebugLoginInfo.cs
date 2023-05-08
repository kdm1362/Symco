using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginInfoDebug : MonoBehaviour
{
    public void Awake()
    {
        // 로그인 정보 확인
        if(SymcoManager.instance == null)
        {
            SymcoManager.symcoDebugInfo("Login Info is NULL please run program from Login Scene");
        }
        else
        {
            string debugInfo = "User ID is ";
            debugInfo += SymcoManager.instance.userLogin.getUserName();
            SymcoManager.symcoDebugInfo(debugInfo);
        }
    }
}
