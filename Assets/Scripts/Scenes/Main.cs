using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour {
    public void ClickPlayButton() {
        SceneManager.LoadScene("Scenes/Init");
    }

    public void ClickOptionButton() {

    }

    public void ClickQuitButton() {
        Application.Quit();
    }
}
