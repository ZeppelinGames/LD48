using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<int> inventoryItems = new List<int>();
    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddItem(int id)
    {
        inventoryItems.Add(id);
    }
    public void RemoveItem(int id)
    {
        inventoryItems.Remove(id);
    }

    public bool hasItem(int id)
    {
        return inventoryItems.Contains(id);
    }
}
