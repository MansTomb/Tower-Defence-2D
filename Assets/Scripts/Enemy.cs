using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO scriptableObject;

    private float _Health;
    private float _Speed;
    private Transform _Target;

    private int _WaypointIndex = 0;
    
    void Start()
    {
        _Health = scriptableObject.health;
        _Speed = scriptableObject.speed;

        _Target = Waypoints._Points[0];
    }

    
    void Update()
    {
        Vector3 dir = _Target.position - transform.position;
        transform.Translate(dir.normalized * _Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _Target.position) <= 0.15f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (_WaypointIndex >= Waypoints._Points.Length - 1)
            return;
        
        _WaypointIndex++;
        _Target = Waypoints._Points[_WaypointIndex];
    }
}
