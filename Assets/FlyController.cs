using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float moveSpeed = 10f;         // 이동 속도
    public float lookSpeed = 2f;          // 마우스 회전 속도
    public float rotationLimit = 85f;     // 상하 회전 제한
    private float xRotation = 0f;         // 카메라 상하 회전 각도

    void Update()
    {
        // 방향키로 이동 처리 (전진/후진, 좌우 이동)
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveSideways = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Space, Ctrl 키로 상하 이동 처리
        float moveUp = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            moveUp = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveUp = -moveSpeed * Time.deltaTime;
        }

        // 이동 벡터 계산 및 이동 적용
        Vector3 move = transform.right * moveSideways + transform.forward * moveForward + transform.up * moveUp;
        transform.position += move;

        // 마우스 입력을 이용한 회전 처리
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // 카메라의 상하 회전 제한 설정
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -rotationLimit, rotationLimit);

        // 회전 적용
        transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.eulerAngles.y + mouseX, 0f);
    }
}
