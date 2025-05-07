using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    public static bool isSafeOpened = false;

    [SerializeField]
    public float speed;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float fallMultiplier;

    [SerializeField]
    private float jumpVelocity;

    [SerializeField]
    private Vector3 footoffset;

    [SerializeField]
    private float footRadius;

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

        // Handle movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        if (moveHorizontal != 0)
        {
            spriteRenderer.flipX = moveHorizontal < 0;
        }

        // Animation state changes
        animator.SetBool(isPlayerWalkAnimatorHash, Mathf.Abs(moveHorizontal) > 0.01f && isOnground);
        animator.SetBool(isPlayerFloatAnimatorHash, !isOnground);

        // Jump
        if (isOnground && Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
        }
    }

    private void FixedUpdate()
    {
        // Check if on the ground
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position + footoffset, footRadius, GroundLayerMask);
        isOnground = hitCollider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + footoffset, footRadius);  // Draw ground check radius
    }
}
