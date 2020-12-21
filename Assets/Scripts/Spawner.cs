using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private LevelSO level = null;
    
    private void Awake()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        var currentWave = level.waves[GetCurrentWave()];
        foreach (var enemy in currentWave.waveSettings)
        {
            for (int i = 0; i < enemy.Value; i++)
            {
                yield return new WaitForSeconds(currentWave.delayBetweenSpawn);
                Instantiate(enemy.Key.enemyPrefab).transform.position = transform.position;   
            }
        }
    }

    private int GetCurrentWave()
    {
        return 0;
    }
}
