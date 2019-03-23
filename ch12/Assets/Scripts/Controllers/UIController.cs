using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Text healthLabel;
    [SerializeField] private InventoryPopup popup;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    private void Start()
    {
        healthBar.maxValue = Managers.Player.maxHealth;
        healthBar.value = Managers.Player.health;
        OnHealthUpdated();
        popup.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            bool isShowing = popup.gameObject.activeSelf;
            popup.gameObject.SetActive(!isShowing);
            popup.Refresh();
        }
    }

    private void OnHealthUpdated()
    {
        healthBar.value = Managers.Player.health;

        string message = Managers.Player.health + " / " + Managers.Player.maxHealth;
        healthLabel.text = message;
    }
}
