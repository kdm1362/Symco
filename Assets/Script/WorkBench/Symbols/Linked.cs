using System.Collections.Generic;
using UnityEngine;

public class Linked : MonoBehaviour
{
    protected Linked nextNode;
    protected Linked previousNode;

    // getter setter
    public void SetLinks(Linked[] links)
    {
        previousNode = links[0];
        nextNode = links[1];
    }
    public Linked[] GetLinks()
    {
        Linked[] result = { nextNode, previousNode };
        return result;
    }

    public void SetNext(Linked node)
    {
        nextNode = node;
    }
    public void SetPrevious(Linked node)
    {
        previousNode = node;
    }

    // 노드의 연결 해제
    public void disconnectLink()
    {
        // 노드를 Pebble 밑으로 이동
        this.transform.parent = GameObject.FindWithTag("Pebble").transform;
        // edge연결을 끊음
        if (previousNode != null)
            previousNode.nextNode = nextNode;
        if (nextNode != null)
            nextNode.previousNode = previousNode;
        previousNode = null;
        nextNode = null;
    }

    // 노드 연결
    // 주어진 노드를 다음에 연결
    public void connectLink(Linked newnode)
    {
        Debug.Log("Connect Symbol");
        // 새 노드를 Flow 밑으로 이동
        newnode.transform.parent = GameObject.FindWithTag("Flow").transform;
        // 새 노드가 현재 노드를 가리키기
        newnode.previousNode = this;
        // 새 노드가 다음 노드 가리키기
        newnode.nextNode = this.nextNode;
        // 다음 노드가 새 노드 가리키기
        this.nextNode.previousNode = newnode;
        // 현재 노드가 새 노드 가리키기
        this.nextNode = newnode;

    }
    

    // 연결 리스트 타고 다니기
    public Linked next()
    {
        return nextNode;
    }
    public Linked prev()
    {
        return previousNode;
    }
}
