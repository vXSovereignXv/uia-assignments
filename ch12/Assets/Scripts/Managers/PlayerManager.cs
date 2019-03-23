﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int health { get; private set; }
    public int maxHealth { get; private set; }

    private NetworkService _network;

    public void StartUp(NetworkService network)
    {
        Debug.Log("Player manager starting...");

        _network = network;

        health = 100;
        maxHealth = 100;

        status = ManagerStatus.Started;
    }

    public void ChangeHealth(int value)
    {
        health += value;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        else if (health < 0)
        {
            health = 0;
        }

        Debug.Log($"Health: {health}/{maxHealth}");
        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    }
}
