using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private LevelSO level = null;

    private int _Health;

    public event Action<int> OnHealthChanged;

    private void Awake()
    {
        _Health = level.health;
    }

    private void OnTriggerEnter2D(Collider2D other1)
    {
        _Health -= other1.GetComponent<Enemy>().damage;
        OnHealthChanged?.Invoke(_Health);
        Debug.Log($"{_Health}");
        Destroy(other1.gameObject);
    }
}
