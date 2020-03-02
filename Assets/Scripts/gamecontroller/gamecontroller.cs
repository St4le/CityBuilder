﻿//Hudson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour
{
    public GameObject[] people;
    public int houses;
    public Vector3 spawnvalues;
    private int pop;
    private float happiness;
    private int iron;
    private int wood;
    private int stone;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public float startwait;
    public Text woodcounter;
    public Text stonecounter;
    public Text ironcounter;
    public Text popcounter;
    public Text happycounter;
    public RawImage sad;
    public RawImage happy;
    public GameObject buildingmenu;
    private float homeless;



    int NewPerson;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(peoplespawner());
        happiness = 0;
        buildingmenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        woodcounter.text = "W= " + wood;
        stonecounter.text = "S= " + stone;
        ironcounter.text = "I= " + iron;
        popcounter.text = "P= " + pop;
        happycounter.text = "H= " + happiness;
        if (happiness < 0)
        {
            happy.enabled = false;
            sad.enabled = true;
        }
        else
        {
            happy.enabled = true;
            sad.enabled = false;
        }
        pop = GameObject.FindGameObjectsWithTag("people").Length; ;
        houses = GameObject.FindGameObjectsWithTag("home").Length;
        if (pop > houses * 4)
        {
            homeless = pop % (houses * 4);
            happiness = homeless * -1;
        }
    }
    IEnumerator peoplespawner()
    {
        yield return new WaitForSeconds(startwait);
        while (true)
        {
            NewPerson = Random.Range (0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), 1, Random.Range(-spawnvalues.z, spawnvalues.z));

            Instantiate(people[NewPerson], spawnPosition + transform.TransformPoint (0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}