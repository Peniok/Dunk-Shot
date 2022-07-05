using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] Transform thisTransform;
    [SerializeField] Transform mainCamera;

    void Update()
    {
        thisTransform.position = mainCamera.position;
    }
}
