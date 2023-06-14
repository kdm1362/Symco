using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    // 카메라를 따라다니기 위한 변수
    private Transform cameraTransform;
    private Vector3 initialOffset;

    // Start is called before the first frame update
    void Start()
    {
        // 카메라와의 상대위치 저장
        cameraTransform = Camera.main.transform;
        initialOffset = transform.position - cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라 따라다니기
        Vector3 targetPosition = cameraTransform.position + initialOffset;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}
