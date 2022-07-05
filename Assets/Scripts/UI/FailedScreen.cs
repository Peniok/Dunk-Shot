using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FailedScreen : MonoBehaviour
{
    [SerializeField] private RectTransform[] elements;
    [SerializeField] List<Vector3> startScale;
    [SerializeField] private Button restartButton, settingsMenu;
    [SerializeField] private GameObject settingsMenuGameObject;

    private bool showScreen;
    private float timeToShow=1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            startScale.Add(elements[i].localScale);
            elements[i].localScale = Vector3.zero;
        }
        restartButton.onClick.AddListener(LevelManager.RestartLevel);
        settingsMenu.onClick.AddListener(ShowSettingsMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (showScreen)
        {
            timeToShow -= Time.deltaTime * elements.Length*3;

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i].localScale = Vector3.Lerp(startScale[i], Vector3.zero, timeToShow+i);
            }
            if(timeToShow+ elements.Length - 1 < 0)
            {
                showScreen = false;
            }
        }
    }
    public void StartShowScreen()
    {
        showScreen = true;
    }
    public void ShowSettingsMenu()
    {
        settingsMenuGameObject.gameObject.SetActive(true);
    }
}
