using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public void YesButtonClicked() {
        SceneManager.LoadScene("IntroScene");
    }

    public void NoButtonClicked() {
        Application.Quit();
    }
}
