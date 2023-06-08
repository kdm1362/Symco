using System.Collections.Generic;
using UnityEngine;

public class Symbol : Linked
{
    // 심볼의 종류 enum 
    // TODO: 추가바람
    public enum Category
    {
        Start,
        End,
        Condition,
        Loop,
        Variable,
        Processing,
        Timer,
        Throttle,
        Yaw,
        Rol,
        Pitch
    };

    // 드래그 구현을 위한 변수
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPoint;
    public float dragDistance = 50f;

    // 심볼의 종류
    public Category id;

    protected void Update()
    {
        // 심볼 드래그 처리
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x - offset.x, mousePosition.y - offset.y, transform.position.z);
            // 드래그 원점으로 부터 거리가 멀어지면 끊기
            float dist = Vector3.Distance(mousePosition, startPoint);
            if (dist > dragDistance)
                disconnectLink();
        }
    }

    void OnMouseDown()
    {
        // 레이캐스트를 사용하여 클릭한 오브젝트가 심볼인지 확인.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = startPoint - transform.position;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
