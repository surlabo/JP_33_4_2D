using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 300f;
    [SerializeField]
    private float detectDisance = 1f;
    [SerializeField]
    private Animator animator;

    private LayerMask layer = 1 << 3 | 1 << 6 ;

    private Rigidbody2D rb;
    private bool canJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        Vector2 vectorDir = new Vector2(dir, 0);
        transform.Translate(vectorDir * Time.deltaTime * speed);

        animator.SetBool("Run", dir != 0);

        var hit = Physics2D.Raycast(transform.position, Vector2.down, detectDisance, 1 << 3);
        if (hit.collider != null)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        
        
        Debug.DrawRay(transform.position, Vector2.down * detectDisance, Color.red);
    }
}
