using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource EndOfLevel, ShootFromBasket;
    
    public void PlayEndOfLevel()
    {
        EndOfLevel.Play();
    }
    public void PlayShootFromBasket()
    {
        ShootFromBasket.Play();
    }
}
