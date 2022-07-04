using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settings, scoreCounter, PauseMenu;
    [SerializeField] Joystick joystick;

    private void Update()
    {
        if( joystick.Direction != Vector2.zero)
        {
            PauseMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
            scoreCounter.gameObject.SetActive(true);
        }
    }
    void Start()
    {
        settingsButton.onClick.AddListener(ShowSettigsMenu);
    }

    void ShowSettigsMenu()
    {
        settings.SetActive(true);
    }
}
