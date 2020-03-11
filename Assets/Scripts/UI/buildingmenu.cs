using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingmenu : MonoBehaviour
{

    private bool Open;
    public GameObject buildingmenuopen;

    public void openmenu()
    {
        buildingmenuopen.gameObject.SetActive(!buildingmenuopen.activeSelf);
    }
}