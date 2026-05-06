using System;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;

    private void randomSpawn()
    {
        Vector3 randPos = new Vector3(
            UnityEngine.Random.Range(-21f, 18f),
            UnityEngine.Random.Range(-21f, 18.5f),
            0f
        );
        Instantiate(enemyPrefab, randPos, Quaternion.identity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomSpawn();
    }
}
