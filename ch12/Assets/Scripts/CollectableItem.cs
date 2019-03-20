using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private string ItemName;

    private void OnTriggerEnter(Collider other)
    {
        Managers.Inventory.AddItem(ItemName);
        Destroy(this.gameObject);
    }
}
