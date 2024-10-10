using System.Collections;
using UnityEngine;

public class AIGenerator : MonoBehaviour
{
    public GameObject prefab; // 생성할 프리팹
    public Vector3 centerPosition; // 중심 위치
    public float spawnRadius = 5f; // 생성 범위 반경
    public float spawnInterval = 2f; // 생성 간격 (초)

    void Start()
    {
        centerPosition = transform.position;
        // 코루틴을 통해 2초마다 프리팹 생성
        StartCoroutine(SpawnPrefabRoutine());
    }

    IEnumerator SpawnPrefabRoutine()
    {
        while (true)
        {
            // 랜덤한 위치 계산 (중심점에서 일정 반경 내에서 생성)
            Vector3 randomPosition = centerPosition + (Random.insideUnitSphere * spawnRadius);
            randomPosition.y = centerPosition.y;

            // 프리팹 생성
            Instantiate(prefab, randomPosition, Quaternion.identity);

            // 생성 간격 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
