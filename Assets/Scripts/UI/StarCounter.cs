using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StarCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starCounter;
    private void Start()
    {
        starCounter.text = PlayerPrefs.GetInt("Stars", 0)+"";
    }
    public void AddStar()
    {
        int stars = int.Parse(starCounter.text) + 1;
        starCounter.text = stars + "";
        PlayerPrefs.SetInt("Stars", stars);
        PlayerPrefs.Save();
    }

}
