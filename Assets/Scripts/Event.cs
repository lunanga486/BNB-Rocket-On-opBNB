using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit() { 
        Application.Quit();
        Debug.Log("Quit");
    }
}
