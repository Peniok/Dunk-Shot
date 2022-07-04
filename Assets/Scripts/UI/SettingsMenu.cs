using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button backButton, soundButton, themeSwitcher;
    [SerializeField] private Image themeSwitcherImage, soundButtonImage, backGroundImage;
    [SerializeField] private Color whiteTheme, blackTheme;
    [SerializeField] CameraMover cameraMover;
    // Start is called before the first frame update
    void Awake()
    {
        backButton.onClick.AddListener(HideSettigsMenu);
        soundButton.onClick.AddListener(SwitchSoundSettings);
        themeSwitcher.onClick.AddListener(SwitchThemeSettings);
        
        if (PlayerPrefs.GetInt("Theme") == 1)
        {
            backGroundImage.color = blackTheme;
            themeSwitcherImage.color = Color.black;
        }
        AudioListener.volume = PlayerPrefs.GetInt("SoundMute");
        if(AudioListener.volume == 0)
        {
            soundButtonImage.color = Color.red;
        }
        else
        {
            soundButtonImage.color = Color.white;
        }
    }

    void HideSettigsMenu()
    {
        gameObject.SetActive(false);
    }
    void SwitchSoundSettings()
    {
        if (AudioListener.volume == 0)
        {
            soundButtonImage.color = Color.white;
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("SoundMute", 1);
        }
        else
        {
            soundButtonImage.color = Color.red;
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("SoundMute", 0);
        }
        PlayerPrefs.Save();
    }
    void SwitchThemeSettings()
    {
        if (themeSwitcherImage.color == Color.white)
        {
            backGroundImage.color = blackTheme;
            themeSwitcherImage.color = Color.black;
            PlayerPrefs.SetInt("Theme",1);
        }
        else
        {
            backGroundImage.color = whiteTheme;
            themeSwitcherImage.color = Color.white;
            PlayerPrefs.SetInt("Theme",0);
        }
        PlayerPrefs.Save();
        cameraMover.ChangeBack();
    }
}
