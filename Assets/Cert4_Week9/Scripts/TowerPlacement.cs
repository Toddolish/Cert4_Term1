using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Towers.Placement;
using Core.Utilities;

public class TowerPlacement : MonoBehaviour
{
    public LayerMask hitLayers;
    // public Tower currentSelectedTower;
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnDrawGizmos()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 1000f);
    }
    private void FixedUpdate()
    {
        // Perform raycats
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(camRay, out hit, 1000f, hitLayers))
            {
                // Check if hitting grid
                IPlacementArea placement = hit.collider.GetComponent<IPlacementArea>();
                if (placement != null)
                {
                    // Get grid point
                    // Position tower to grid element
                    transform.position = placement.Snap(hit.point, new IntVector2(1, 1));
                }
            }
        }
    }
}
