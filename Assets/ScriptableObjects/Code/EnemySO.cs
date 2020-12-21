using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public float health;
    public float speed;
}
