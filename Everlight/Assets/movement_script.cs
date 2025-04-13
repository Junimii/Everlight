using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    public float speed;

    [SerializeField]
     private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal*speed, rb2d.velocity.y);
        Debug.Log(moveHorizontal);

        if (moveHorizontal != 0){
            spriteRenderer.flipX = moveHorizontal < 0;
        }


        
        animator.SetBool("isPlayerWalk", Mathf.Abs(moveHorizontal) >  0.01);
    }
}
