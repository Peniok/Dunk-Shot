using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongratulationText : MonoBehaviour
{
    [SerializeField] private Transform perfectWord, bounceWord, numberWord;
    [SerializeField] private TextMeshPro perfectWordText, bounceWordText, numberWordText;

    private float timeForAnim;
    bool isPerfect, isBounced;
    public void SpawnText(bool perfect, bool bounced, int scoreCount, Vector3 pos)
    {
        gameObject.SetActive(true);
        if (bounced)
        {
            isBounced = true;
            bounceWord.position = pos + Vector3.up * 0.5f;
        }
        if (perfect)
        {
            isPerfect = true;
            perfectWord.position = pos + Vector3.up * 0.5f;
            bounceWord.position += Vector3.up * 0.5f;
        }
        numberWord.position = pos;
        enabled = true;
        timeForAnim = 0;
        numberWordText.text = "+ " + scoreCount;
    }
    private void Update()
    {

        timeForAnim += Time.deltaTime;
        if (isBounced)
        {
            bounceWord.position+= Vector3.up * 0.05f;
            bounceWordText.color = new Color(bounceWordText.color.r, bounceWordText.color.g, bounceWordText.color.b, JumpLinearGraph(Mathf.Max(0, timeForAnim - 0.4f)));
        }
        if (isPerfect&&timeForAnim<1.2f)
        {
            perfectWordText.color = new Color(perfectWordText.color.r, perfectWordText.color.g, perfectWordText.color.b, JumpLinearGraph(Mathf.Max(0, timeForAnim -0.2f)));
            perfectWord.position += Vector3.up * 0.05f;
        }
        if (timeForAnim < 1)
        {
            numberWord.position += Vector3.up * 0.05f;
            //Debug.Log(JumpLinearGraph(timeForAnim));
            numberWordText.color = new Color(numberWordText.color.r, numberWordText.color.g, numberWordText.color.b, JumpLinearGraph(timeForAnim));
        }
        
        if (timeForAnim > 1.4f)
        {
            enabled = false;
            isPerfect = false;
            isBounced = false;
            gameObject.SetActive(false);
        }
    }
    private float JumpLinearGraph(float time)
    {
        return (Mathf.Cos((time * Mathf.PI * 2f) + Mathf.PI) + 1f) / 2f;
    }
}
