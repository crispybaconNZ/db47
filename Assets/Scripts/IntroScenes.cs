using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScenes : MonoBehaviour {
    public void Instructions() {
        SceneManager.LoadScene("Instructions");
    }

    public void Play() {
        Debug.Log("Click");
        SceneManager.LoadScene("Game");
    }
}
