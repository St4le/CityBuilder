using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    public RectTransform selectSqaureImage;

    Vector3 StartPos;

    Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        selectSqaureImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            selectSqaureImage.gameObject.SetActive(false);
        }

        if(Input.GetMouseButton(0))
        {
            if(!selectSqaureImage.gameObject.activeInHierarchy)
            {
                selectSqaureImage.gameObject.SetActive(true);
            }

            endPos = Input.mousePosition;

            Vector3 squareStart = StartPos;
            squareStart.z = 0f;

            Vector3 centre = (squareStart + endPos) / 2f;

            selectSqaureImage.position = centre;

            float sizeX = Mathf.Abs(squareStart.x - endPos.x);
            float sizeY = Mathf.Abs(squareStart.y - endPos.y);

            selectSqaureImage.sizeDelta = new Vector2(sizeX, sizeY);
        }
    }
}
