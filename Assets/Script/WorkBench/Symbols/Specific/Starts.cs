using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starts : Symbol
{
    // Start is called before the first frame update
    void Start()
    {
        this.id = Category.Start;
        // 끝과 흐름 연결
        Symbol End = GameObject.FindWithTag("End").GetComponent<Symbol>();
        Symbol[] arg = { null, End };
        SetLinks(arg);
    }
}
