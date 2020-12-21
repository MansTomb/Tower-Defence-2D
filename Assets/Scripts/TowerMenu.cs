using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    [SerializeField] private InputReader input = null;
    [HideInInspector] public GameObject target = null;

    private void Awake()
    {
        input.OnTouch += Open;
        gameObject.SetActive(false);
    }
    
    private void Open(GameObject tower)
    {
        if (tower.CompareTag("Tower") == false)
            return;
        target = tower;
        gameObject.SetActive(true);
        transform.position = target.transform.position;
    }
    
    public void OnTowerSell()
    {
        Debug.Log($"sell");
        Destroy(target);
        gameObject.SetActive(false);
    }
}
