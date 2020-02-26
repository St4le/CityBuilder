using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    public LayerMask clickablesLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickablesLayer))
            {
                ClickOn clickOnScript = rayHit.collider.GetComponent<ClickOn>();
                clickOnScript.CurrentlySelected = !clickOnScript.CurrentlySelected;

                clickOnScript.Clicked();

            }
        }
    }
}
