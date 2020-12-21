using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "SO/Level")]
public class LevelSO : ScriptableObject
{
    public int health;
    
    public List<WaveSO> waves;
}
