using System.Collections;
using UnityEngine;

public class AIGenerator : MonoBehaviour
{
    public GameObject prefab; // ������ ������
    public Vector3 centerPosition; // �߽� ��ġ
    public float spawnRadius = 5f; // ���� ���� �ݰ�
    public float spawnInterval = 2f; // ���� ���� (��)

    void Start()
    {
        centerPosition = transform.position;
        // �ڷ�ƾ�� ���� 2�ʸ��� ������ ����
        StartCoroutine(SpawnPrefabRoutine());
    }

    IEnumerator SpawnPrefabRoutine()
    {
        while (true)
        {
            // ������ ��ġ ��� (�߽������� ���� �ݰ� ������ ����)
            Vector3 randomPosition = centerPosition + (Random.insideUnitSphere * spawnRadius);
            randomPosition.y = centerPosition.y;

            // ������ ����
            Instantiate(prefab, randomPosition, Quaternion.identity);

            // ���� ���� ���
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
