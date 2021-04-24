using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent events;
    public List<int> itemCheck = new List<int>();
     public LayerMask triggerLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerLayers == (triggerLayers | (1 << collision.gameObject.layer)))
        {
            bool hasItems = true;
            foreach (int itemId in itemCheck) {
                if (!Inventory.instance.hasItem(itemId)) {
                    hasItems = false;
                }
            }

            if (hasItems) {
                events.Invoke();
            }
        }
    }
}
