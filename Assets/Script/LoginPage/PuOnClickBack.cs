using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuOnClickBack : MonoBehaviour
{
    private PuInterface pu;

    private void Start()
    {
        pu = this.gameObject.GetComponent<PuInterface>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pu.close();
        }
    }
}
