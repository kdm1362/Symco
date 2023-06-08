using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public Linked node;
    // Start is called before the first frame update
    void Start()
    {
        // 시작시 위쪽 심볼의 Symbol컴포넌트 가져오기
        node = transform.parent.gameObject.GetComponent<Linked>();
        Debug.Log(node);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Linked col = collision.GetComponent<Linked>();
        if (col == null || col.next() != null)
        {
            return;
        }
        Debug.Log("colied");
        node.connectLink(col);
    }
}
