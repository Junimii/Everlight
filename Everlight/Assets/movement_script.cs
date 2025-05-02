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

    [SerializeField]
    private float fallMutiplier;

    [SerializeField]
    private float jumpVelocity;

    [SerializeField]
    private Vector3 footoffset;

    [SerializeField]
    private float footRedius;

    [SerializeField]
    private LayerMask GroundLayerMask;
    
    private bool isOnground;

    private readonly static int isPlayerWalkAnimatorHash = Animator.StringToHash("isPlayerWalk");

    private readonly static int isPlayerFloatAnimatorHash = Animator.StringToHash("isPlayerFloat");
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

        animator.SetBool(isPlayerWalkAnimatorHash, Mathf.Abs(moveHorizontal) >  0.01 && isOnground);
        animator.SetBool(isPlayerFloatAnimatorHash,!isOnground);

        if(isOnground && Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
        }
        Debug.Log("isOnground = " + isOnground);

        
    }
  private void FixedUpdate()
  {
    Collider2D hitCollider = Physics2D.OverlapCircle(transform.position + footoffset, footRedius, GroundLayerMask);
    isOnground = hitCollider != null;

  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position + footoffset, footRedius);
  }
}
