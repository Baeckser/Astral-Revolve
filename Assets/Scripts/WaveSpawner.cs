using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { spawning, waiting, counting };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public float searchCountdown = 1f;

    public SpawnState state = SpawnState.counting;

    // Start is called before the first frame update
    //Checks if spawnPoints have been assigned 
    void Start()
    {
        if (spawnPoints.Length == 0)
        {   
            Debug.LogError("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            if (state == SpawnState.waiting)
            {
                Debug.Log(EnemyIsAlive());
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (waveCountdown <= 0)
            {
                if (state != SpawnState.spawning)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    //Checks if there are any waves left to instantiate 
    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("All Waves Complete!");
            Win_Menu.GameIsWon = true;
            return;
        }
        else
        {
            nextWave++;
        }
    }
    //Checking if there are any enemies left
    bool EnemyIsAlive ()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    //Coroutine for spawning a new wave
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.name);
        state = SpawnState.spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.waiting;
         
        yield break;
    }

    //Assigning a (random) spawnpoint to the next wave
    void SpawnEnemy (Transform _enemy)
    {
        Debug.Log("Spawning Enemy:" + _enemy.name);

        Transform _sp = spawnPoints[nextWave];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
