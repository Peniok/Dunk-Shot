using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private bool newBasket, BallEntered, CanSpawnStar;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform BoneToScale;
    [SerializeField] private Transform parentForBall;
    private float timeToEnableCollider=1000000;
    [SerializeField] private Collider2D colliderOfBasket;
    [SerializeField] private GameObject Star;


    private void Start()
    {
        EventManager.OnBallFallenIntoBasket += CheckForDisableThisBasket;
        if(CanSpawnStar && Random.Range(0, 5) == 4)
        {
            Star.gameObject.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallEntered == false)
        {
            //Debug.Log("name");
            //Debug.Log(collision.name);

            //Debug.Break();
            collision.GetComponent<Ball>().PrepareToNewJump(newBasket, this);
            colliderOfBasket.enabled = false;
            EventManager.BallFallenIntoBasket(newBasket, this);
            newBasket = false;
            BallEntered = true;

            //ball.PrepareToNewJump
            /*ball.DisablePhysics();
            ball.MoveToParent();
            ball.SetNewParent(parentTransform);*/
        }
        else
        {
            BallEntered = false;
            timeToEnableCollider = Time.time + 0.1f;
        }
        
    }
    private void Update()
    {
        if (timeToEnableCollider < Time.time)
        {
            colliderOfBasket.enabled = true;
            timeToEnableCollider = 100000000000;
        }
    }
    void CheckForDisableThisBasket(bool isThisnewBasket, Basket basket)
    {
        if (basket.GetParent() != parentTransform && newBasket==false)
        {
            //Debug.Log(name);
            parentTransform.gameObject.SetActive(false);
        }
    }
    public Transform GetParent()
    {
        return parentTransform;
    }
    public Transform GetParentForBall()
    {
        return parentForBall;
    }
    public void ChangeScaleOfBones(float scaleOfset)
    {
        BoneToScale.localScale = new Vector3(1+scaleOfset,1,1);
        parentForBall.localPosition = Vector3.Lerp(Vector3.zero, Vector3.down*0.25f, scaleOfset);
    }
    private void OnDisable()
    {
        EventManager.OnBallFallenIntoBasket -= CheckForDisableThisBasket;
    }
}
