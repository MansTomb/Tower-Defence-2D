using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] private InputReader input = null;
    [HideInInspector] public GameObject target = null;

    private void Awake()
    {
        input.OnTouch += Open;
        gameObject.SetActive(false);
    }
    
    private void Open(GameObject buildPlace)
    {
        if (buildPlace.CompareTag("Build Place") == false)
            return;
        
        target = buildPlace;
        gameObject.SetActive(true);
        transform.position = target.transform.position;
    }
    
    public void OnTowerCreate(TowerSO prefab)
    {
        Debug.Log($"creation");
        Instantiate(prefab.towerPrefab, target.transform, false);
        gameObject.SetActive(false);
    }
}
