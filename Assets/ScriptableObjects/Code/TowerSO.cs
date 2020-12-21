﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "SO/Tower")]
public class TowerSO : ScriptableObject
{
    public GameObject towerPrefab;

    public float shootInterval;
    public float range;
    public float damage;

    public float buildPrice;
}
