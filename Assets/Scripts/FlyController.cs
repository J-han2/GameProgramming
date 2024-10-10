using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float moveSpeed = 10f;         // �̵� �ӵ�
    public float lookSpeed = 2f;          // ���콺 ȸ�� �ӵ�
    public float rotationLimit = 85f;     // ���� ȸ�� ����
    private float xRotation = 0f;         // ī�޶� ���� ȸ�� ����

    void Update()
    {
        // ����Ű�� �̵� ó�� (����/����, �¿� �̵�)
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveSideways = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Space, Ctrl Ű�� ���� �̵� ó��
        float moveUp = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            moveUp = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveUp = -moveSpeed * Time.deltaTime;
        }

        // �̵� ���� ��� �� �̵� ����
        Vector3 move = transform.right * moveSideways + transform.forward * moveForward + transform.up * moveUp;
        transform.position += move;

        // ���콺 �Է��� �̿��� ȸ�� ó��
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // ī�޶��� ���� ȸ�� ���� ����
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -rotationLimit, rotationLimit);

        // ȸ�� ����
        transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.eulerAngles.y + mouseX, 0f);
    }
}
