﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//commented to fix
public class ResourceManager : MonoBehaviour
{
    public static Code.Resources resources;
    public int Khyber;
    public AudioSource RusticHour;

    // Start is called before the first frame update
    void Start()
    {
        resources = new Code.Resources();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("water").GetComponent<TextMesh>().text = " " + resources.GetWater();
        GameObject.Find("power").GetComponent<TextMesh>().text = " " + resources.GetPower();
        GameObject.Find("food").GetComponent<TextMesh>().text = " " + resources.GetFood();
        GameObject.Find("khyber").GetComponent<TextMesh>().text = " " + resources.GetKhyber();
        GameObject.Find("titanium").GetComponent<TextMesh>().text = " " + resources.GetTitanium();
        GameObject.Find("iridium").GetComponent<TextMesh>().text = " " + resources.GetIridium();
        Victory();

    }

    //1. Food and Water reach a certain amount = Population Victory
    //2. Metals reach a certain amount = Structure victory
    //3. When energy reaches a certain amount = Energy Victory

    

    public static Code.Resources ToAdd(string planetName, int[] buildings){
        return Code.Resources.GetOptimizedPlanetGeneration(planetName, buildings);
    }
    public void Victory()
    {
        if (resources.GetWater() + resources.GetFood() >= 200)
        {
            //SceneManager.LoadScene("PopVictory");
            Debug.Log("Population Victory");
            RusticHour.Stop();
        }
        if (resources.GetKhyber() + resources.GetIridium() + resources.GetTitanium() >= 200)
        {
            //SceneManager.LoadScene("StructureVictory");
            Debug.Log("Structure Victory");
            RusticHour.Stop();
        }
        if (resources.GetPower() >= 200)
        {
            //SceneManager.LoadScene("EnergyVictory");
            Debug.Log("Energy Victory");
            RusticHour.Stop();
        }
    }
}