using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeRender : MonoBehaviour
{
    [SerializeField]
    public GameObject edgePref;

    private GameObject edgeInstance;
    private Symbol node;
    // 엣지는 아래쪽만 확인할 것
    Vector3 beforeTransformNext;
    Vector3 beforeTransformThis;

    // Start is called before the first frame update
    void Start()
    {
        // 초기 위치 저장
        beforeTransformThis = transform.position;

        // 시작하면 Symbol 컴포넌트를 가져와서
        // 다음 노드랑 연결하는 엣지를 생성하고 그릴것
        node = GetComponent<Symbol>();
        if(node.next()!=null)
            drawEdge();
    }

    private void Update()
    {
        if (checkMovement())
            drawEdge();
    }

    // 다음 심볼의 이동을 감지
    private bool checkMovement()
    {
        // 현재 노드가 움직였어도 true
        if (beforeTransformThis != transform.position)
        {
            return true;
        }
        // 다음 노드가 없으면 false
        if (node.next() == null)
        {
            destroyEdge();
            return false;
        }
        // 이전 위치기록이 없으면 false
        if (beforeTransformNext == null)
        {
            beforeTransformNext = node.next().transform.position;
            return false;
        }

        Vector3 nowTransform = node.next().transform.position;
        if(beforeTransformNext != nowTransform)
        {
            beforeTransformNext = nowTransform;
            return true;
        }
        return false;
    }

    private void createEdge()
    {
        if(edgeInstance != null)
        {
            // 인스턴스화된 edge가 이미 있을 경우
            updatePosition((Symbol)node.next());
            return;
        }
        if(edgePref == null)
        {
            // 인스턴스화할 edge prefab이 지정되지 않은 경우
            Debug.Log("edge 리소스가 지정되지 않았습니다");
            return;
        }
        edgeInstance = Instantiate(edgePref);
        edgeInstance.transform.parent = this.transform;
        updatePosition((Symbol) node.next());
    }

    private void destroyEdge()
    {
        if(edgeInstance != null)
        {
            Destroy(edgeInstance);
        }
    }

    public void updatePosition(Symbol next)
    {
        // TODO: 넘겨받은 심볼과 현재 심볼의 위치로 엣지를 그리도록
        // 중간지점 찾기
        Vector3 midPoint = (node.afterPort.position + next.beforePort.position) / 2f;
        // 엣지 길이 결정
        float distance = Vector3.Distance(node.afterPort.position, next.beforePort.position);
        // 엣지 각도 결정
        Vector3 direction = (node.afterPort.position - next.beforePort.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion dir = Quaternion.Euler(0f,0f,angle);

        // 계산된 값 집어넣기
        edgeInstance.transform.position = midPoint;
        edgeInstance.transform.localScale = new Vector3(edgeInstance.transform.localScale.x, distance, 1f);
        edgeInstance.transform.rotation = dir;
    }

    public void drawEdge()
    {
        // 다음 노드를 가져오기
        Symbol next = (Symbol)node.next();
        // 다음노드가 연결되 있는지 확인
        if(next == null)
        {
            // 다음 노드가 없으면 종료
            destroyEdge();
            return;
        }
        // 다음 노드가 있으면 생성하고 위치 수정
        createEdge();

    }

}
