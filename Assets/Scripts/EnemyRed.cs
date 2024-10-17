using System.Collections;
using UnityEngine;

public class EnemyRed : MonoBehaviour
{
    public float moveSpeed = 3.0f;  // �̵� �ӵ�
    private GameObject Base;
    private Vector3 direction;
    private GameManager manager;

    public float lifeTime = 10.0f;

    void Start()
    {
        // "base" �±װ� �ִ� ������Ʈ�� ã�� Base ������ �Ҵ�
        Base = GameObject.FindGameObjectWithTag("base");
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        // 10�� �� ����
        StartCoroutine(LifeTimer());
    }

    void Update()
    {
        SetDirectionTowardsBase();  // Base�� ��ġ�� ���ϴ� ������ �� ������ ������Ʈ
        MoveTowardsBase();  // Base�� ��ġ�� �̵� ó��
    }

    void MoveTowardsBase()
    {
        if (Base != null)
        {
            // ���� ��ġ���� Base�� ��ġ�� �̵�
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    void SetDirectionTowardsBase()
    {
        if (Base != null)
        {
            // Base ��ġ�� ���ϴ� ���� ���
            Vector3 targetDirection = Base.transform.position - transform.position;
            direction = targetDirection.normalized;
        }
    }

    // ������ �ð� �� ����
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    // �浹 ó��
    private void OnCollisionEnter(Collision collision)
    {
        // "red" ���̾� ������Ʈ�� �浹 �� �ڱ� �ڽ� ����
        if (collision.gameObject.layer == LayerMask.NameToLayer("red"))
        {
            manager.AddKillCount();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.Defeat();
    }
}
