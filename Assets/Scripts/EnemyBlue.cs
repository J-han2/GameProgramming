using System.Collections;
using UnityEngine;

public class EnemyBlue : MonoBehaviour
{
    public float moveSpeed = 3.0f;  // �̵� �ӵ�
    private GameObject Base;
    private Vector3 direction;
    private Rigidbody rb;  // Rigidbody ������Ʈ
    private GameManager manager;

    public float lifeTime = 10.0f;

    public float jumpForce = 1f;  // ���� ��
    bool isJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody ������Ʈ �Ҵ�
        isJump = false;
        Base = GameObject.FindGameObjectWithTag("base");
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        StartCoroutine(LifeTimer());
    }

    void FixedUpdate()  // Physics ������Ʈ�� FixedUpdate���� ó��
    {
        SetDirectionTowardsBase();
        MoveTowardsBase();
    }

    void MoveTowardsBase()
    {
        if (Base != null)
        {
            // Rigidbody�� ����� ��ġ �̵�
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void SetDirectionTowardsBase()
    {
        if (Base != null)
        {
            Vector3 targetDirection = Base.transform.position - transform.position;
            direction = targetDirection.normalized;
        }
    }

    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("blue"))
        {
            manager.AddKillCount();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("obstacles")) //��ֹ��� �浹 ��
        {
            if (!isJump)
                StartCoroutine(Jump());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.Defeat();
    }

    IEnumerator Jump()
    {
        isJump = true;
        rb.AddForce(Vector3.up * jumpForce);  // ���� �� �߰�
        yield return new WaitForSeconds(1.0f);  // ���� �� ���� �ð� ���
        isJump = false;
    }
}
