using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : Symbol
{
    // Start is called before the first frame update
    void Start()
    {
        this.id = Category.End;
        // 시작과 흐름 연결
        Symbol start = GameObject.FindWithTag("Start").GetComponent<Symbol>();
        Symbol[] arg = { start, null };
        SetLinks(arg);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
