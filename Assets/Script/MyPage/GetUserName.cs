using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetUserName : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI username;
    private void Awake()
    {
        if (SymcoManager.instance == null)
            return;
        string un = SymcoManager.instance.userLogin.getUserName();
        username.text = un;
    }
}
