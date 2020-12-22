using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<Coroutine> _GoingWaves = new List<Coroutine>();

    public event Action<GameObject> OnSpawn;

    private void OnDisable()
    {
        foreach (var wave in _GoingWaves)
        {
            StopCoroutine(wave);
        }
    }

    public void SpawnWave(WaveSO wave)
    {
        _GoingWaves.Add(StartCoroutine(Spawn(wave)));
    }

    private IEnumerator Spawn(WaveSO wave)
    {
        foreach (var enemy in wave.waveSettings)
        {
            for (int i = 0; i < enemy.Value; i++)
            {
                yield return new WaitForSeconds(wave.delayBetweenSpawn);
                var obj = Instantiate(enemy.Key.enemyPrefab);
                obj.transform.position = transform.position;
                OnSpawn?.Invoke(obj);
            }
        }
    }
}
