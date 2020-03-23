using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementSystem : MonoBehaviour
{
    public GameObject target;
    public GameObject structure;
    public GameObject Roadspot;

    private bool secondClick;

    Vector3 Roadstart;
    Vector3 Roadend;
    Vector3 truePos;
    public float gridSize;

    private List<GameObject> placeableObjectPrefab;

    public bool InUI;

    public List<Transform> BuildingsBuildings;

    private Vector3 buildingPos;
    private GameObject currentBuilding;
    bool placingRoad;

    private Vector3 scaleChange;
    public void Start()
    {
        secondClick = false;
    }

    public void Update()
    {
        if (!InUI && currentBuilding != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (Input.GetMouseButtonDown(0) && !placingRoad)
                {
                    SetColliders(currentBuilding, true);
                    currentBuilding = null;
                }
                
                if (hit.transform.CompareTag("Terrain"))
                {
                    buildingPos = hit.point;
                }



                if (placingRoad)
                {
                    NewRoad(hit.point);
                }
            }
        }

        if(currentBuilding != null)
        {
            target.transform.position = buildingPos;

            target.transform.position += new Vector3(0, 0.1f, 0);
        }

        
    }

    public void NewBuilding(GameObject buildingPrefab)
    {
        currentBuilding = Instantiate(buildingPrefab, buildingPos, Quaternion.identity) as GameObject;
        SetColliders(currentBuilding, false);
        structure = currentBuilding;
    }
    public void NewRoad(Vector3 mousePosition)
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        if (!secondClick)
        {
            Roadstart = mousePosition;
            secondClick = true;
        }
        else
        {
            
            Roadend = mousePosition;
            secondClick = false;
            float distance = Vector3.Distance(Roadstart, Roadend);
            Vector3 midpoint = Vector3.Lerp(Roadstart, Roadend, 0.5f);
            Vector3 direction = Roadstart - Roadend;
            //Roadspot = Instantiate(roadPrefab, midpoint, Quaternion.identity) as GameObject;
            Roadspot = currentBuilding;
            Roadspot.transform.position = midpoint;
            Roadspot.transform.localScale = new Vector3(distance, 0.2f, 1);
            Roadspot.transform.right = direction;

            SetColliders(currentBuilding, true);
            currentBuilding = null;
            structure = null;
            placingRoad = false;
        }

    }

    public void StartPlacingRoad()
    {
        placingRoad = true;
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
