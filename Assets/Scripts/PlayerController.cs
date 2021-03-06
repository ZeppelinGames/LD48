using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 10;
    public float maxVelo = 5;

    public Rect groundTrigger;

    private bool canJump = true;
    private bool isGrounded = false;

    public float stepDelay = 0.3f;
    private float prevStep = 0;

    public AudioClip step;
    public AudioClip jump;

    private AudioSource audioSource;
    private Rigidbody2D rig;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canJump)
        {
            isGrounded = onGround();
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                audioSource.clip = jump;
                audioSource.Play();

                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        float h = 0;
        if (Input.GetKey(KeyCode.A)) { h = -1; }
        if (Input.GetKey(KeyCode.D)) { h = 1; }

        transform.localScale = new Vector3(h != 0 ? h : 1, 1, 1);

        anim.SetBool("moving", h > 0 || h < 0 ? true : false);
        if(h > 0 || h < 0) {
            if (onGround())
            {
                if (Time.time - prevStep > stepDelay)
                {
                    audioSource.clip = step;
                    audioSource.Play();
                    prevStep = Time.time;
                }
            }
        }

        // rig.AddForce(new Vector2(h * moveSpeed, 0), ForceMode2D.Force);
        rig.velocity = new Vector2(h * moveSpeed, rig.velocity.y);
        //rig.velocity = new Vector2(Mathf.Clamp(rig.velocity.x, -maxVelo, maxVelo), rig.velocity.y);
    }

    bool onGround()
    {
        bool onground = false;
        if(Physics2D.OverlapBox((Vector2)transform.position + groundTrigger.position,groundTrigger.size,0))
        {
            onground = true;
        }
        return onground;
    }

    private void OnDrawGizmos()
    {
        if(groundTrigger != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube((Vector2)transform.position + groundTrigger.position, groundTrigger.size);
        }
    }

    public void setJump(bool jump)
    {
        canJump = jump;
    }
}
