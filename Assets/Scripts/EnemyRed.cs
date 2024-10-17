using System.Collections;
using UnityEngine;

public class EnemyRed : MonoBehaviour
{
    public float moveSpeed = 3.0f;  // 이동 속도
    private GameObject Base;
    private Vector3 direction;
    private GameManager manager;

    public float lifeTime = 10.0f;

    void Start()
    {
        // "base" 태그가 있는 오브젝트를 찾아 Base 변수에 할당
        Base = GameObject.FindGameObjectWithTag("base");
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        // 10초 후 삭제
        StartCoroutine(LifeTimer());
    }

    void Update()
    {
        SetDirectionTowardsBase();  // Base의 위치를 향하는 방향을 매 프레임 업데이트
        MoveTowardsBase();  // Base의 위치로 이동 처리
    }

    void MoveTowardsBase()
    {
        if (Base != null)
        {
            // 현재 위치에서 Base의 위치로 이동
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    void SetDirectionTowardsBase()
    {
        if (Base != null)
        {
            // Base 위치로 향하는 벡터 계산
            Vector3 targetDirection = Base.transform.position - transform.position;
            direction = targetDirection.normalized;
        }
    }

    // 지정된 시간 후 삭제
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    // 충돌 처리
    private void OnCollisionEnter(Collision collision)
    {
        // "red" 레이어 오브젝트와 충돌 시 자기 자신 삭제
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
