using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Basket CurentBasket;
    [SerializeField] private Joystick joystick;
    [SerializeField] private BallProjection ballProjection;
    [SerializeField] private Ball ball;
    private Vector2 lastDir;
    [SerializeField] private float force;
    private bool CanShoot=true;
    [SerializeField] SoundController soundController;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnBallFallenIntoBasket += ResetControlling;
    }
    void Update()
    {
        
        if (CanShoot)
        {
            if (joystick.Direction != -lastDir )
            {
                float joystickMagnitude = joystick.Direction.magnitude;
                CurentBasket.ChangeScaleOfBones(joystickMagnitude);
                CurentBasket.GetParent().up = new Vector3(lastDir.x, lastDir.y,0);

                if (joystickMagnitude == 0 )
                {

                    if (lastDir.magnitude >= 0.5f)
                    {
                        ball.Jump(ball.GetPos(), lastDir * force);
                        soundController.PlayShootFromBasket();
                        CanShoot = false;
                    }
                    else
                    {
                        ballProjection.StopCalculating();
                    }
                    
                }

                lastDir = -joystick.Direction;
                if (joystickMagnitude >= 0.5f)
                {
                    ballProjection.CalculateProjection(ball.GetPos(), lastDir * force);
                    ballProjection.ContinueCalculating();
                    
                }
                else
                {
                    ballProjection.StopCalculating();
                }
            }
        }
        
    }
    void ResetControlling(bool NewBasket, Basket basket)
    {
        CanShoot = true;
        CurentBasket = basket;
        
    }
    private void OnDisable()
    {
        EventManager.OnBallFallenIntoBasket -= ResetControlling;
    }
}
