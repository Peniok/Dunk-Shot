using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button resumeButton, restartButton, settingsButton, pauseBuuton;
    [SerializeField] private GameObject settings, pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseBuuton.onClick.AddListener(EnablePause);
        resumeButton.onClick.AddListener(DisablePause);
        restartButton.onClick.AddListener(LevelManager.RestartLevel);
        settingsButton.onClick.AddListener(EnableSettings);
    }

    void EnablePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    void EnableSettings()
    {
        settings.SetActive(true);
    }
    void DisablePause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
