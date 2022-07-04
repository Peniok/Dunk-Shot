using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    

    public void AddScore(int score)
    {
        textMesh.text = (int.Parse(textMesh.text) + score) + "";
    }
}
