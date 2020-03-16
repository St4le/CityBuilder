using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementSystem : MonoBehaviour
{
    public GameObject target;
    public GameObject structure;

    Vector3 truePos;
    public float gridSize;

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
                {
                    buildingPos = hit.point;
                }


            }
        }

        if(currentBuilding != null)
        {
            target.transform.position = buildingPos;
        }
    }

    public void NewBuilding(GameObject buildingPrefab)
    {
        currentBuilding = Instantiate(buildingPrefab, buildingPos, Quaternion.identity) as GameObject;
        SetColliders(currentBuilding, false);
        structure = currentBuilding;


    }

    public void SetColliders(GameObject go, bool value)
    {
        foreach (Collider collider in go.GetComponentsInChildren<Collider>())
        {
            collider.enabled = value;
        }
    }
    void LateUpdate()
    {
        if(structure != null)
        {
            truePos.x = Mathf.Floor(target.transform.position.x / gridSize) * gridSize;
            truePos.y = target.transform.position.y;//Mathf.Floor(target.transform.position.y / gridSize) * gridSize;
            truePos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize;

            structure.transform.position = truePos;
        }

    }
}
