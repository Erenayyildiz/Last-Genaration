using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void restart()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
    public void SetQuality(int qual)
    {
           QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void Return()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
