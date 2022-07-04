using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StarCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starCounter;
    
    public void AddStar()
    {
        starCounter.text = (int.Parse(starCounter.text) + 1) + "";
    }
}
