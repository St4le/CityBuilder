using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementSystem : MonoBehaviour
{

    private List<GameObject> placeableObjectPrefab;

    public bool InUI;

    public List<Transform> Buildings;

    private Vector3 buildingPos;
    private GameObject currentBuilding;
    public void Start()
    {
        
    }

    public void Update()
    {
        if (!InUI && currentBuilding != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SetColliders(currentBuilding, true);
                    currentBuilding = null;
                }
                
                if (hit.transform.CompareTag("Terrain"))
                buildingPos = hit.point;

            }
        }

        if(currentBuilding != null)
        {
            currentBuilding.transform.position = buildingPos;
        }
    }

    public void NewBuilding(GameObject buildingPrefab)
    {
        currentBuilding = Instantiate(buildingPrefab, buildingPos, Quaternion.identity) as GameObject;
        SetColliders(currentBuilding, false);
        
    }

    public void SetColliders(GameObject go, bool value)
    {
        foreach (Collider collider in go.GetComponentsInChildren<Collider>())
        {
            collider.enabled = value;
        }
    }
}
