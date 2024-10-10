using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;
    public GameObject[] bulletPrefabs;
    public Transform shootOrigin;


    void Update()
    {
        // �̵� ó��
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        // ȸ�� ó��
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed, 0);

        // ���콺 ���� ��ư Ŭ�� �� �� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �� ���� �Ѿ� ������ �� �ϳ��� �����ϰ� ����
        int randomIndex = Random.Range(0, bulletPrefabs.Length);
        GameObject selectedBullet = bulletPrefabs[randomIndex];

        Instantiate(selectedBullet, shootOrigin.position, shootOrigin.rotation);
    }
}
