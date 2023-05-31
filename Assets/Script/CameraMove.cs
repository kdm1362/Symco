using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    public float cameraSpeed = 1.0f; // 카메라 이동 속도 변수

    private Vector3 dragOrigin;
    private bool dragging = false;

    public void resetPosition()
    {
        transform.position = new Vector3(610.0f, 241.0f, -10.0f);
    }

    public bool IsPointerOverUIObject(Vector2 touchPos)
    {
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = touchPos;

        List<RaycastResult> results = new List<RaycastResult>();


        EventSystem.current
        .RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

    void LateUpdate()
    {
        // 터치 입력 또는 마우스 입력을 처리합니다.
        if (Input.GetMouseButtonDown(0))
        {
            // 드래그를 시작한 위치의 객체를 검출합니다.
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null && !IsPointerOverUIObject(Input.mousePosition))
            {
                dragOrigin = Input.mousePosition;
                dragging = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        // 드래그 중일 때 카메라를 이동시킵니다.
        if (dragging)
        {
            Vector3 difference = Input.mousePosition - dragOrigin;
            dragOrigin = Input.mousePosition;

            // 카메라 이동 방향을 역으로 적용하여 월드 좌표로 변환합니다.
            Vector3 cameraMovement = -difference * Time.deltaTime * cameraSpeed;
            cameraMovement = Camera.main.transform.TransformDirection(cameraMovement);
            cameraMovement.z = 0f;

            // 카메라를 이동시킵니다.
            transform.Translate(cameraMovement, Space.World);
        }
    }
}
