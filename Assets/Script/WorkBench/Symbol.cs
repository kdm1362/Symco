using UnityEngine;

public class Symbol : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    // 이중 연결 리스트 구성 요소
    public Symbol previousSymbol;
    public Symbol nextSymbol;

    void Update()
    {
        // 심볼 드래그 처리
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x - offset.x, mousePosition.y - offset.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        // 레이캐스트를 사용하여 클릭한 오브젝트가 심볼인지 확인합니다.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
