using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCheck : MonoBehaviour
{
    public List<GameObject> selectableObjects;
    public List<GameObject> selectedObjects;
    private Vector3 mousePos1;
    private Vector3 mousePos2;


    // Start is called before the first frame update
    void Awake()
    {
        selectableObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        }
        if(Input.GetMouseButtonDown(1))
        {
            ClearSelection();
        }

        if(Input.GetMouseButtonUp(0))
        {
            mousePos2 = Camera.main.WorldToViewportPoint(Input.mousePosition);

            if(mousePos1 != mousePos2)
            {
                SelectObjects();
            }
        }
    }

    public void SelectObjects()
    {
        List<GameObject> RemoveObjects = new List<GameObject>();


        if(Input.GetKey(KeyCode.LeftControl) == false)
        {
            ClearSelection();
        }

        Rect selectRect = new Rect(mousePos1.x, mousePos1.y, mousePos2.x - mousePos1.x, mousePos2.y - mousePos1.y);
        
        foreach(GameObject selectObject in selectableObjects)
        {
            if(selectableObjects != null)
            {
                if (selectRect.Contains(Camera.main.WorldToViewportPoint(selectObject.transform.position), true))
                {
                    selectedObjects.Add(selectObject);
                    selectObject.GetComponent<ClickOn>().CurrentlySelected = true;
                    selectObject.GetComponent<ClickOn>().Clicked();
                    Debug.Log("hello");
                }
            }
            else
            {
                RemoveObjects.Add(selectObject);
            }

        }

        if(RemoveObjects.Count > 0)
        {
            foreach(GameObject Remove in RemoveObjects)
            {
                selectableObjects.Remove(Remove);
            }

            RemoveObjects.Clear();
        }
    }


    public void ClearSelection()
    {

    }
}
