using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;     // 총알의 속도
    public float lifeDuration = 5f;  // 총알의 생존 시간

    private float lifeTimer;  // 생존 시간을 추적하는 타이머

    void Start()
    {
        lifeTimer = lifeDuration;
    }

    void Update()
    {
        // 총알을 앞으로 전진시킵니다.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 총알의 생존 시간을 감소시킵니다.
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);  // 생존 시간이 다하면 총알을 파괴합니다.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);  // 오브젝트와 충돌 후 총알을 파괴합니다.
    }
}
