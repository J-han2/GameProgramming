using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;     // �Ѿ��� �ӵ�
    public float lifeDuration = 5f;  // �Ѿ��� ���� �ð�

    private float lifeTimer;  // ���� �ð��� �����ϴ� Ÿ�̸�

    void Start()
    {
        lifeTimer = lifeDuration;
    }

    void Update()
    {
        // �Ѿ��� ������ ������ŵ�ϴ�.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // �Ѿ��� ���� �ð��� ���ҽ�ŵ�ϴ�.
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);  // ���� �ð��� ���ϸ� �Ѿ��� �ı��մϴ�.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);  // ������Ʈ�� �浹 �� �Ѿ��� �ı��մϴ�.
    }
}
