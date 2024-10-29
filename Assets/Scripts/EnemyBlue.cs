using System.Collections;
using UnityEngine;

public class EnemyBlue : MonoBehaviour
{
    public float moveSpeed = 3.0f;  // 이동 속도
    private GameObject Base;
    private Vector3 direction;
    private Rigidbody rb;  // Rigidbody 컴포넌트
    private GameManager manager;

    public float lifeTime = 10.0f;

    public float jumpForce = 1f;  // 점프 힘
    bool isJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody 컴포넌트 할당
        isJump = false;
        Base = GameObject.FindGameObjectWithTag("base");
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        StartCoroutine(LifeTimer());
    }

    void FixedUpdate()  // Physics 업데이트는 FixedUpdate에서 처리
    {
        SetDirectionTowardsBase();
        MoveTowardsBase();
    }

    void MoveTowardsBase()
    {
        if (Base != null)
        {
            // Rigidbody를 사용한 위치 이동
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("obstacles")) //장애물과 충돌 시
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
        rb.AddForce(Vector3.up * jumpForce);  // 점프 힘 추가
        yield return new WaitForSeconds(1.0f);  // 점프 후 일정 시간 대기
        isJump = false;
    }
}
