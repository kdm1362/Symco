using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymcoManager : MonoBehaviour
{
    //  싱글톤
    public static SymcoManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // 여기에 유지하고 싶은 변수 public으로 작성
    public HUserFile userLogin;

    // 함수
    public static void symcoDebugInfo(string debug)
    {
        Debug.Log("Symco_info: " + debug);
    }

    public static void symcoDebugError(System.Exception e)
    {
        Debug.LogError("Symco_Error: " + e);
    }

    public static void symcoDebugError(string e)
    {
        Debug.LogError("Symco_Error: " + e);
    }

}
