using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springForce = 10;

    public Sprite coiledSpring;
    public Sprite extendedSpring;

    private SpriteRenderer spr;
    private AudioSource aud;

    // Start is called before the first frame update
    void OnEnable()
    {
        spr = GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();
    }

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
        {
            aud.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D rig = collision.GetComponent<Rigidbody2D>();

            rig.velocity += (Vector2)transform.up * springForce;

            spr.sprite = extendedSpring;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spr.sprite = coiledSpring;
    }
}
