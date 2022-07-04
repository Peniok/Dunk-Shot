using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] Transform thisTransform;
    [SerializeField] Transform mainCamera;
    //[SerializeField] SpriteRenderer[] spriteRenderers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.position = mainCamera.position;
    }
    /*void Disablerenderers()
    {

    }*/
}
