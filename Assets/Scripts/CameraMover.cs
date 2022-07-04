using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Transform thisTransform;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Color WhiteTheme, BlackTheme;
    float minimumY;
    private void Start()
    {
        EventManager.OnBallFallenIntoBasket += CameraTakesNewLimits;
        minimumY = ball.GetPos().y-1;
        ChangeBack();
    }

    void Update()
    {
        //thisTransform.position += new Vector3(0,ball.GetVelocity().y,0) * Time.deltaTime;//Vector3.up * Time.deltaTime * Mathf.Max(0.5f,( ball.GetPos().y - (thisTransform.position.y -2)));
        if (ball.GetPos().y > thisTransform.position.y-2f)
        {
            thisTransform.position += Vector3.up * Time.deltaTime * Mathf.Max(0.1f, ball.GetPos().y - (thisTransform.position.y - 2));
        }
        else if (ball.GetPos().y < thisTransform.position.y- 2.2f && ball.GetPos().y> minimumY)
        {
            thisTransform.position += Vector3.down * Time.deltaTime *  Mathf.Max(0.1f,thisTransform.position.y- 2.2f - ball.GetPos().y) ;
        }
    }
    void CameraTakesNewLimits(bool newBasket, Basket basket)
    {
        minimumY = basket.GetParent().position.y-1;
        //Debug.Break();
    }
    public void ChangeBack()
    {
        if (PlayerPrefs.GetInt("Theme") == 0)
        {
            mainCamera.backgroundColor = WhiteTheme;
        }
        else
        {
            mainCamera.backgroundColor = BlackTheme;
        }
    }
    private void OnDisable()
    {
        EventManager.OnBallFallenIntoBasket -= CameraTakesNewLimits;
    }
}
