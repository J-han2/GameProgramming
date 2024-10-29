using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f; // ���콺 �ΰ���
    public GameObject[] bulletPrefabs;
    public VisualEffect[] bulletEffects;
    public GameObject playerHead;
    public Material[] playerMat;
    public Transform shootOrigin;
    private Rigidbody rb;
    public Transform cameraTransform; // ī�޶��� Transform

    

    bool bullettype = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bullettype = false;
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ���� ��޴ϴ�.
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShooting();
    }

    void HandleMovement()
    {
        // �÷��̾� �̵� ó��
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(rb.position + move);
    }

    void HandleRotation()
    {
        // �¿� ȸ�� ó��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseX, 0);
    }

    void HandleShooting()
    {
        // ���콺 ���� ��ư Ŭ�� �� �� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bullettype = !bullettype;
            playerHead.GetComponent<SkinnedMeshRenderer>().material = playerMat[bullettype ? 0 : 1];
        }
    }

    void Shoot()
    {
        GameObject selectedBullet = bulletPrefabs[bullettype ? 0 : 1];
        bulletEffects[bullettype ? 0 : 1].Play();
        Instantiate(selectedBullet, shootOrigin.position, shootOrigin.rotation);
    }

    
}
