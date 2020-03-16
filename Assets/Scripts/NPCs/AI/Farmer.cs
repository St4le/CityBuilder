using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public LayerMask farmableLayer;

    private GameObject House;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(House.gameObject.transform.position, 300, Vector3.up, out hit, farmableLayer))
        {

        }
    }
}
