using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3.0f;  // 이동 속도
    public float rotationSpeed = 200.0f;  // 회전 속도
    private Vector3 randomDirection;

    public float lifeTime = 10.0f;
    void Start()
    {
        // 랜덤한 방향을 설정
        SetRandomDirection();
        // 10초 후 삭제
        StartCoroutine(LifeTimer());
    }

    void Update()
    {
        MoveRandomly();
    }

    
    void MoveRandomly()
    {
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    
    void SetRandomDirection()
    {
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomZ = Random.Range(-1.0f, 1.0f);
        randomDirection = new Vector3(randomX, 0, randomZ).normalized;
    }

    //5초 뒤에 삭제
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
