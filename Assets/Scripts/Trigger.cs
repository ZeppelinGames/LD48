using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent events;
    public LayerMask triggerLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerLayers == (triggerLayers | (1 << collision.gameObject.layer)))
        {
            events.Invoke();
        }
    }
}
