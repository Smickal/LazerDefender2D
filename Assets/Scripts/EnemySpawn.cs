using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField]bool isLooping;
    WaveConfigSO currentWave;

    private void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        StartCoroutine(SpawnAllWaves());
    }


    IEnumerator SpawnAllWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoints().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);  
    }
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

}
