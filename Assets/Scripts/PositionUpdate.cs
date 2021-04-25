using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdate : MonoBehaviour
{

    public PosUpdate[] posUp;
    public void SetPos()
    {
        foreach (PosUpdate pos in posUp)
        {
            pos.t.position = pos.pos;
        }
    }
}
