using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING , WAITING, COUNTING};
    [SerializeField] Wave[] waves;

    private int currentWave;

    public Transform[] enemySpawner;
    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float waveCountDown = 0;

    private SpawnState state = SpawnState.COUNTING;



    private void Start()
    {
        waveCountDown = timeBetweenWaves;
        currentWave = 0;
    }

    private void Update()
    {
        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnZombies(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }
        

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnZombies(GameObject enemy)
    {
        int randomInt = Random.RandomRange(1, enemySpawner.Length);
        Transform randomSpawners = enemySpawner[randomInt];
        Instantiate(enemy, randomSpawners.position, randomSpawners.rotation);
    }

}
