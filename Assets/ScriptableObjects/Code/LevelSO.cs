using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "SO/Level")]
public class LevelSO : ScriptableObject
{
    public int health;
    public int startCoins;
    public float DelayBetweenWaves;

    public List<WaveSO> waves;
}
