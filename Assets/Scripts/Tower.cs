using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerSO towerSettings;

    private List<Enemy> _EnemiesInRadius = new List<Enemy>();
    private float _ShootDelay = 0;

    private void Awake()
    {
        _ShootDelay = Time.fixedTime + towerSettings.shootInterval;
        GetComponent<CircleCollider2D>().radius = towerSettings.range;
    }

    private void Update()
    {
        if (CanAttack())
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_EnemiesInRadius.Count > 0)
        {
            var enemyClosestToCastle = _EnemiesInRadius.First();
            ShootAt(enemyClosestToCastle);
            _ShootDelay += towerSettings.shootInterval;
        }
    }

    private void ShootAt(Enemy enemy)
    {
        enemy.ApplyDamage(towerSettings.damage);
    }

    private bool CanAttack()
    {
        return Time.fixedTime >= _ShootDelay;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _EnemiesInRadius.Add(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            _EnemiesInRadius.Remove(other.gameObject.GetComponent<Enemy>());
    }
}
