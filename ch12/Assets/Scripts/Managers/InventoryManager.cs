using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public string equippedItem { get; private set; }

    private Dictionary<string, int> _items;
    private NetworkService _network;

    public void StartUp(NetworkService network)
    {
        Debug.Log("Inventory manager starting...");

        _network = network;

        UpdateData(new Dictionary<string, int>());

        status = ManagerStatus.Started;
    }

    public void UpdateData(Dictionary<string, int> items)
    {
        _items = items;
    }

    public Dictionary<string, int> GetData()
    {
        return _items;
    }

    public bool EquipItem(string name)
    {
        if(_items.ContainsKey(name) && equippedItem != name)
        {
            equippedItem = name;
            Debug.Log($"Equipped {name}");
            return true;
        }

        equippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name)
    {
        if(_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
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

    public bool ConsumeItem(string name)
    {
        if(_items.ContainsKey(name))
        {
            _items[name]--;
            if(_items[name] == 0)
            {
                _items.Remove(name);
            }
        }
        else
        {
            Debug.Log($"Cannot consume " + name);
            return false;
        }

        DisplayItems();
        return true;
    }
}
