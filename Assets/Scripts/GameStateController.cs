using System;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private LevelSO level = null;
    [SerializeField] private Spawner spawner = null;
    [SerializeField] private Finish finish = null;

    private float _DelayBetweenWaves;
    
    public int Health { get; private set; }
    public int Coins { get; private set; }
    public int WavesAmount { get; private set; }
    public int CurrentWave { get; private set; }

    public event Action<int> CoinsChanged;
    public event Action<int> HealthChanged;
    public event Action<int> CurrentWaveChanged;
    
    private void RegisterToEnemyDied(GameObject enemy) => enemy.GetComponent<Enemy>().OnDied += EnemyDied;
    
    private void Awake()
    {
        Coins = level.startCoins;
        Health = level.health;
        WavesAmount = level.waves.Count;
        CurrentWave = 1;
        _DelayBetweenWaves = Time.fixedTime + level.DelayBetweenWaves;
    }

    private void Update()
    {
        if (CurrentWave - 1 == WavesAmount)
        {
            return;
        }
        else if (Time.fixedTime >= _DelayBetweenWaves)
        {
            var wave = level.waves[CurrentWave - 1];
            spawner.SpawnWave(wave);
            
            _DelayBetweenWaves += wave.waveDuration + _DelayBetweenWaves;
            CurrentWaveChanged?.Invoke(CurrentWave);
            CurrentWave++;
        }
    }

    private void OnEnable()
    {
        finish.OnEnemyFinished += EnemyFinished;
        spawner.OnSpawn += RegisterToEnemyDied;
        
        CoinsChanged?.Invoke(Coins);
        HealthChanged?.Invoke(Health);
        CurrentWaveChanged?.Invoke(CurrentWave);
    }

    private void OnDisable()
    {
        finish.OnEnemyFinished -= EnemyFinished;
        spawner.OnSpawn -= RegisterToEnemyDied;
    }

    private void EnemyDied(Enemy enemy)
    {
        Coins += enemy.CoinsOnDie;
        enemy.OnDied -= EnemyDied;
        CoinsChanged?.Invoke(Coins);
    }

    private void EnemyFinished(GameObject enemy)
    {
        var enemyComp = enemy.GetComponent<Enemy>();
        
        Health -= enemyComp.Damage;
        HealthChanged?.Invoke(Health);
        
        enemyComp.OnDied -= EnemyDied;
    }

    public bool TryBuy(int cost)
    {
        if (Coins >= cost)
        {
            Coins -= cost;
            CoinsChanged?.Invoke(Coins);
            return true;
        }

        return false;
    }

    public void Sell(int sellValue)
    {
        Coins += sellValue;
        CoinsChanged?.Invoke(Coins);
    }
}
