using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState
    { 
        SPAWNING, WAITING, COUNTING
    };


    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemy;
        public int count;
        public float rate;
    }

    public Wave wave;
    [SerializeField] GameObject target;
    [SerializeField] GameObject shopRef;
    private Shop shop;

    public Transform[] spawnLocations;

    public float timeBetweenWaves = 5f;

    private bool isShopActive = false;

    public float waveCountdown;

    private float searchCountDown = 1f;

    private SpawnState spawnState = SpawnState.COUNTING;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        shop = shopRef.GetComponent<Shop>();
    }

    private void Update()
    {
        if(spawnState == SpawnState.WAITING)
        {
            if(!IsEnemyAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <=0)
        {
            if (spawnState != SpawnState.SPAWNING)
            {
                if (isShopActive)
                {
                    shop.DisableShop();
                    isShopActive = false;
                }
                StartCoroutine(SpawnWave(wave));
            }
        }
        else
        {
            if (!isShopActive)
            {
                shop.EnableShop();
                isShopActive = true;
            }
           
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        ++wave.count;
        spawnState = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
    }

    private bool IsEnemyAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }


    IEnumerator SpawnWave(Wave wave)
    {
        spawnState = SpawnState.SPAWNING;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        spawnState = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {
        Debug.Log("Spawning Enemy");

        if (spawnLocations.Length == 0)
        {
            Debug.Log("No spawn location");
            return;
        }
        Transform _sp = spawnLocations[Random.Range(0, spawnLocations.Length)];
      

        GameObject enemy = Instantiate(_enemy,_sp.position,_sp.rotation);
        enemy.GetComponent<Enemy>().Target = target;
    }
}
        