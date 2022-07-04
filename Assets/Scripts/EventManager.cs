using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
    public static event Action<bool, Basket> OnBallFallenIntoBasket;
    public static void BallFallenIntoBasket(bool newBasket, Basket basket) => OnBallFallenIntoBasket?.Invoke(newBasket, basket);
}
