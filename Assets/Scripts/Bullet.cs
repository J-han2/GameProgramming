using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float lifeTime = 5.0f;

    private void Start()
    {
        StartCoroutine(LifeTimer());
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    //5초 뒤에 삭제
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
