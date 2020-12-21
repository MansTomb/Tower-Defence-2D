using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Camera camera = null;
    
    private LayerMask layer = 1 << 8;

    public event Action<GameObject> OnTouch;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            
            Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layer);

            if (hitInfo.collider != null)
            {
                OnTouch?.Invoke(hitInfo.collider.gameObject);
            }
        }
    }
}
