using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springForce = 10;

    public Sprite coiledSpring;
    public Sprite extendedSpring;

    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
        {
            Vector2 fwd = transform.up;
            if (Vector2.Dot(collision.transform.position, fwd) < -0.5f)
            {
                Rigidbody2D rig = collision.GetComponent<Rigidbody2D>();

                

                rig.velocity += fwd * springForce;

                spr.sprite = extendedSpring;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spr.sprite = coiledSpring;
    }
}
