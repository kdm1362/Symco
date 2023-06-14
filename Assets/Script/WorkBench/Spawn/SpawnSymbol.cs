using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSymbol : MonoBehaviour
{
    [SerializeField]
    public GameObject variPref;

    private float positionOffX = 250f;

    public void OnClick()
    {
        GameObject parent = GameObject.FindWithTag("Pebble");
        GameObject vari = Instantiate(variPref);

        // 부모 오브젝트를 Pebble로
        vari.transform.parent = parent.transform;

        // 화면 내에 생성되도록
        Transform cam = Camera.main.transform;
        vari.transform.position = new Vector3(cam.position.x + positionOffX, cam.position.y, 0f);
    }
}
