using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;
    public GameObject[] bulletPrefabs;
    public Transform shootOrigin;


    void Update()
    {
        // 이동 처리
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

        // 회전 처리
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed, 0);

        // 마우스 왼쪽 버튼 클릭 시 총 발사
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 두 가지 총알 프리팹 중 하나를 랜덤하게 선택
        int randomIndex = Random.Range(0, bulletPrefabs.Length);
        GameObject selectedBullet = bulletPrefabs[randomIndex];

        Instantiate(selectedBullet, shootOrigin.position, shootOrigin.rotation);
    }
}
