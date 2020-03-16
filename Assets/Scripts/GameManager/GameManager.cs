using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public List<GameObject> FarmerHouses = new List<GameObject>();
    public List<GameObject> AI = new List<GameObject>();

    private int HouseNum;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <AI.Count; i++)
        {
            float spacing = -2;
            Vector3 pos = new Vector3(spacing * 1, 0, 0);
            Instantiate(AI[i], pos, Quaternion.identity);
            AssignFarmerHouse();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignFarmerHouse()
    {
        FarmerHouses = GameObject.FindGameObjectsWithTag("Farmer House").ToList();

        if(FarmerHouses.Count >= 1)
        {
            foreach(GameObject item in FarmerHouses)
            {

                HouseNum++;
            }
        }
    }

}
