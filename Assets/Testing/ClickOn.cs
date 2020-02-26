using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    public bool CurrentlySelected = false;

    public MeshRenderer meshRenderer;

    public Material Mat1;

    public Material Mat2;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.gameObject.GetComponent<SelectionCheck>().selectableObjects.Add(this.gameObject);
        Clicked();

    }

    public void Clicked()
    {
        if (CurrentlySelected == false)
        {
            meshRenderer.material = Mat1;
        }
        else
        {
            meshRenderer.material = Mat2;
            Debug.Log("Hello gamers");
        }
    }

}
