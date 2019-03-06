using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private Dictionary<string, int> _items;

    public void StartUp()
    {
        Debug.Log("Inventory manager starting...");

        _items = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        StringBuilder itemDisplay = new StringBuilder("Items: ");

        foreach(var item in _items)
        {
            itemDisplay.Append($"{item.Key} ({item.Value}) ");
        }

        Debug.Log(itemDisplay.ToString());
    }

    public void AddItem(string name)
    {
        if(_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }

        DisplayItems();
    }
}
