using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSymbol : MonoBehaviour
{
    [SerializeField]
    public GameObject variPref;

    public void OnClick()
    {
        GameObject parent = GameObject.FindWithTag("Pebble");
        GameObject vari = Instantiate(variPref);
        vari.transform.parent = parent.transform;
    }
}
