using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingmenu : MonoBehaviour
{

    private bool Open;
    public GameObject buildingmenuopen;

    public void openmenu()
    {
        Open = !Open;
        if (Open == false)
        {
          
            buildingmenuopen.gameObject.SetActive(false);
        }
        if (Open == true)
        {
            buildingmenuopen.gameObject.SetActive(true);

        }

    }
}