using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO enemySettings = null;
    [SerializeField] public Image healthBar = null;

    private float _Health;
    private float _Speed;
    private int _Damage;
    private Transform _Target;

    public float health => _Health;
    public int damage => _Damage;
    
    
    private int _WaypointIndex = 0;
    
    void Start()
    {
        _Health = enemySettings.health;
        _Speed = enemySettings.speed;
        _Damage = enemySettings.damage;

        healthBar.fillAmount = 1;
        
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

    public void ApplyDamage(float dmg)
    {
        _Health -= dmg;
        healthBar.fillAmount = _Health / enemySettings.health;
        if (_Health <= 0)
            Destroy(gameObject);
    }

    private void GetNextWaypoint()
    {
        if (_WaypointIndex >= Waypoints._Points.Length - 1)
            return;
        
        _WaypointIndex++;
        _Target = Waypoints._Points[_WaypointIndex];
    }
}
