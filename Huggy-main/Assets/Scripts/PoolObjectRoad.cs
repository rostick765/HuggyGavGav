using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectRoad : MonoBehaviour
{
    private Transform poolParent;
    public GameObject prefab;
    public GameObject prefabBlocks; // ������ �����������
    public int poolCount = 10;
    public int obstaclePoolCount = 5; // ���������� ����������� �� ������ ������
    public Transform cam;
    private GameObject[] poolAR;
    private float currentZ = 14.26435f; // ����������� �������� ���������� z
    public float offsetZ = 25; // ��������, �� ������� ����� ������������� ���������� z

    private int currentIndex = 0; // ������ ������� �������� ������
    [SerializeField] private float speed;


    void Start()
    {
        poolParent = transform;
        poolAR = new GameObject[poolCount];

        for (int i = 0; i < poolCount; i++)
        {
            Vector3 spawnPosition = new Vector3(-10.28687f, -5.19f, currentZ + (i * offsetZ));
            poolAR[i] = Instantiate(prefab, spawnPosition, poolParent.rotation, poolParent);
            poolAR[i].SetActive(true);

            // ����� ����������� �� ������ ������
            SpawnObstacles(poolAR[i].transform);
        }

        StartCoroutine(DisableRoadsRoutine());
    }

    IEnumerator DisableRoadsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.7f);

            poolAR[currentIndex].SetActive(false);

            // ����������� ����������� ������ � ����� ����
            GameObject disabledRoad = poolAR[currentIndex];
            disabledRoad.transform.position += new Vector3(0f, 0f, poolCount * offsetZ);
            disabledRoad.SetActive(true);

            // ����� ����������� �� ����� ������
            SpawnObstacles(disabledRoad.transform);

            currentIndex = (currentIndex + 1) % poolCount;
        }
    }

    void SpawnObstacles(Transform road)
    {
        for (int i = 0; i < obstaclePoolCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-2.25f, 4.58f), road.position.y - -6.27f, road.position.z + (i * offsetZ));
            GameObject obstacle = Instantiate(prefabBlocks, spawnPosition, Quaternion.identity, road);
            obstacle.SetActive(true);
        }
    }

    void Update()
    {
        float moveSpeed = speed * Time.deltaTime;
        transform.Translate(Vector3.back * moveSpeed, Space.World);
    }
}
