using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private Transform thisTransform;
    [SerializeField] private Collider2D thisCollider;
    Vector3 startPos, startScale;
    private float timeToMove, timeToScale;
    bool Getted;
    int BallLayer;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform.eulerAngles = Vector3.zero;
        startScale = thisTransform.localScale;
        startPos = thisTransform.position;
        BallLayer = LayerMask.NameToLayer("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (Getted==false)
        {
            timeToMove += Time.deltaTime*0.5f;
            thisTransform.position = Vector3.Lerp(startPos, startPos + Vector3.up*0.5f, (Mathf.Cos((timeToMove * Mathf.PI * 2f) + Mathf.PI) + 1f) / 2f);
            if (timeToMove > 1)
            {
                timeToMove = 0;
            }
        }
        else
        {
            timeToScale += Time.deltaTime;
            thisTransform.localScale = Vector3.Lerp(startScale, Vector3.zero, timeToScale);
            thisTransform.eulerAngles += new Vector3(0,0,2*(timeToScale+0.3f)) ;
            if (timeToScale > 1)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer== BallLayer)
        {
            thisCollider.enabled = false;
            Getted = true;
        }
    }
}
