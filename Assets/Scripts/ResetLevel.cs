using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResetLevel : MonoBehaviour
{
    public UnityEvent resetEvents;
    public PosUpdate[] posUpdates;

    public void ResetLVL()
    {
        resetEvents.Invoke();
        foreach(PosUpdate posUp in posUpdates)
        {
            posUp.t.position = posUp.pos;
        }
    }
}

[System.Serializable]
public class PosUpdate
{
    public Transform t;
    public Vector3 pos;

    public PosUpdate(Transform t, Vector3 pos)
    {
        this.t = t;
        this.pos = pos;
    }
}
