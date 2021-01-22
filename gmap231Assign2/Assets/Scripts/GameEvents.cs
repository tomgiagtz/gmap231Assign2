using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    void Awake()
    {
        current = this;
    }

    public event Action<int> onCoinPickup;
    public void CoinPickup(int id)
    {
        if (onCoinPickup != null)
        {
            onCoinPickup(id);
        }
    }
}
