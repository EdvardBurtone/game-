using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirx = 0f;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpspeed = 7f;
     
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * movespeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpspeed);
        }
        AnimationUpdateState();
    }
    

    private void AnimationUpdateState()
    {
        

        if (dirx > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
