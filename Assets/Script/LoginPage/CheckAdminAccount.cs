using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAdminAccount : MonoBehaviour
{
    // Start is called before the first frame update
    HUser handleUser;
    void Awake()
    {
        handleUser = new HUser();
        handleUser.checkAdminAcount();
    }
}
