using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3.0f;  // �̵� �ӵ�
    public float rotationSpeed = 200.0f;  // ȸ�� �ӵ�
    private Vector3 randomDirection;

    public float lifeTime = 10.0f;
    void Start()
    {
        // ������ ������ ����
        SetRandomDirection();
        // 10�� �� ����
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

    //5�� �ڿ� ����
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
