using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketChosen : MonoBehaviour
{
    // Singleton instance
    public static RocketChosen Instance { get; private set; }

    // Variable chosenRocket as an integer
    public int chosenRocket;

    void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this;  // Assign this instance to the singleton
            DontDestroyOnLoad(gameObject);  // Prevent this object from being destroyed when changing scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy this object if another instance already exists
        }
    }

    // Example method to set the chosenRocket value
    public void SetChosenRocket(int rocketId)
    {
        chosenRocket = rocketId;
    }

    // Example method to get the chosenRocket value
    public int GetChosenRocket()
    {
        return chosenRocket;
    }
}
