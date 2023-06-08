using System.Collections.Generic;
using UnityEngine;

public class Linked : MonoBehaviour
{
    protected Linked nextNode;
    protected Linked previousNode;

    // getter setter
    public void SetLinks(Linked[] links)
    {
        nextNode = links[0];
        previousNode = links[1];
    }
    public Linked[] GetLinks()
    {
        Linked[] result = { nextNode, previousNode };
        return result;
    }

    public Linked GetNext()
    {
        return nextNode;
    }
    public Linked GetPrevious()
    {
        return previousNode;
    }
    public void SetNext(Linked node)
    {
        nextNode = node;
    }
    public void SetPrevious(Linked node)
    {
        previousNode = node;
    }

    public void disconnectLink()
    {
        Debug.Log("Disconnected Symbol");
        // edge연결을 끊음
        if (previousNode != null)
            previousNode.nextNode = nextNode;
        if (nextNode != null)
            nextNode.previousNode = previousNode;
        previousNode = null;
        nextNode = null;
    }

    // TODO: 노트 제거
    // TODO: 

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
