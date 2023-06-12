using System.Collections.Generic;
using UnityEngine;

public class Symbol : Linked
{
    // 심볼의 종류 enum
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
    private bool isLinked = false;
    private Vector3 offset;
    private Vector3 startPoint;
    public float dragDistance = 50f;

    // 심볼의 종류
    public Category id;

    // 엣지가 연결 될 위치
    public Transform beforePort;
    public Transform afterPort;

    protected void Awake()
    {
        // 초기화가 되지 전에 등록되어야 함. 에디터 상에서 미리 연결해 둘 것
        // 엣지가 연결 될 위치 등록
        GameObject before = transform.Find("beforePort").gameObject;
        GameObject after = transform.Find("afterPort").gameObject;
        beforePort = before.transform;
        afterPort = after.transform;
    }

    protected void Update()
    {
        // 심볼 드래그 처리
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x - offset.x, mousePosition.y - offset.y, transform.position.z);
            // 드래그 원점으로 부터 거리가 멀어지면 끊기
            if (isLinked)
            {
                float dist = Vector3.Distance(mousePosition, startPoint);
                if (dist > dragDistance)
                {
                    disconnectLink();
                }
            }
        }
    }

    protected void OnMouseDown()
    {
        // 레이캐스트를 사용하여 클릭한 오브젝트가 심볼인지 확인.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            isLinked = next() != null;
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = startPoint - transform.position;
        }
    }

    protected void OnMouseUp()
    {
        isDragging = false;
    }
}
