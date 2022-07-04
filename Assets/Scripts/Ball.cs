using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D thisRigidbody;
    [SerializeField] private Transform thisTransform, thisParent;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private StarCounter starCounter;
    [SerializeField] private CongratulationText congratulationText;
    [SerializeField] private LevelManager levelManager;
    private bool isMovingToCenter;
    private int basketLayer, wallLayer, starLayer, bounced, PerfectCounter=2;
    //[SerializeField] Collider2D LastBasket;
    //private float timeToIgnoreCollisions;
    private void Start()
    {
        basketLayer = LayerMask.NameToLayer("Basket");
        wallLayer = LayerMask.NameToLayer("Wall");
        starLayer = LayerMask.NameToLayer("Star");
    }
    private void Update()
    {
        if (thisTransform.position.y< thisParent.position.y-3)
        {
            levelManager.ShowFailedScreen();
            enabled = false;
        }
        if (isMovingToCenter)
        {
            thisTransform.position = Vector3.MoveTowards(thisTransform.position,thisParent.position,Time.deltaTime);
            if (Vector3.Distance(thisTransform.position, thisParent.position) < 0.1f)
            {
                thisTransform.position = thisParent.position;
                isMovingToCenter = false;
            }
        }
    }
    public void Jump(Vector3 pos, Vector3 force)
    {
        thisRigidbody.simulated = true;
        thisTransform.position = pos;
        thisRigidbody.velocity = force;
        thisRigidbody.angularVelocity = -force.x*100;
        //timeToIgnoreCollisions = Time.time + 0.2f;
    }
    /*public void MoveToParent()
    {
        IsMovingToCenter = true;
    }*/
    public Vector3 GetPos()
    {
        return thisTransform.position;
    }
    public Vector3 GetVelocity()
    {
        return thisRigidbody.velocity;
    }
    public void PrepareToPhysicsScene()
    {
        spriteRenderer.enabled = false;
        enabled = false;
    }
    /*public void SetNewParent(Transform parent)
    {
        
    }*/
    public void PrepareToNewJump(bool isNewBasket,Basket basket)
    {
        DisablePhysics();
        isMovingToCenter = true;
        if (isNewBasket)
        {
            thisParent = basket.GetParentForBall();
            thisTransform.parent = basket.GetParentForBall();
            int score = (bounced + 1) * PerfectCounter;
            scoreCounter.AddScore(score);
            bool wasBounced=false;
            if (bounced == 1)
            {
                wasBounced = true;
            }
            bool wasPerfect = false;
            if (PerfectCounter > 1)
            {
                wasPerfect = true;
            }
            congratulationText.SpawnText(wasPerfect, wasBounced, score, GetPos());
            bounced = 0;
            PerfectCounter += 1;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Time.time> timeToIgnoreCollisions)
        {
            if (collision != LastBasket)
            {
                LastBasket = collision;
                EventManager.BallFallenIntoBasket(true, LastBasket.transform.parent);
            }
            else
            {
                EventManager.BallFallenIntoBasket(false, collision.transform.parent);
            }
            DisablePhysics();
        }
    }*/
    public void DisablePhysics()
    {
        //Debug.Log(name);
        thisRigidbody.simulated = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == basketLayer)
        {
            PerfectCounter = 1;
            //Debug.Log(collision.gameObject.name);
            //Debug.Break();
            //Debug.Log(collision.gameObject.name);
        }
        else if (collision.gameObject.layer == wallLayer)
        {
            bounced = 1;
            //Debug.Log(collision.gameObject.name);
        }
        //Debug.Log("Called");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == starLayer)
        {
            starCounter.AddStar();
        }
    }
    /*private void OnDisable()
    {
        
    }*/
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != LastBasket)
        {
            LastBasket = collision;
            EventManager.BallFallenIntoBasket(true);
        }
        else
        {
            EventManager.BallFallenIntoBasket(false);
        }
        thisRigidbody.simulated = false;
    }*/
    /*private void OnDisable()
    {
        Debug.Log(name);
        EventManager.OnBallFallenIntoBasket -= PrepareToNewJump;
    }*/
}
