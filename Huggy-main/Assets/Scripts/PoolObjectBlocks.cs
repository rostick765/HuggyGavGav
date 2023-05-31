using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectBlocks : MonoBehaviour
{
    private Transform poolParentBlocks;
    public GameObject prefabBlocks;
    public int poolCountBlocks = 10;
    public Transform cam;
    private GameObject[] poolARBlocks;
    private RaycastHit hit;
    private Vector3 roadPosition = new Vector3(10.28687f, 5.093344f, 16.17435f); // Координаты дороги
    private float offsetY = 4f; // Величина опускания по оси y
    private float offsetZ = 5;

    void Start()
    {
        poolParentBlocks = transform;
        poolARBlocks = new GameObject[poolCountBlocks];


        for (int i = 0; i < poolCountBlocks; i++)
        {
            Vector3 spawnPositionBlocks = new Vector3(Random.Range(-2.25f, 4.58f), roadPosition.y - offsetY, roadPosition.z + (i * offsetZ));
            poolARBlocks[i] = Instantiate(prefabBlocks, spawnPositionBlocks, Quaternion.identity, poolParentBlocks);
            poolARBlocks[i].SetActive(true);
        }
    }

}
