using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_Jump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private LayerMask groundLayer;
    Animator animator;

    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpPower);
       
    }
    
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(/*位置*/transform.position, /*半径*/0.5f, /*方向*/Vector2.down, /*長さ*/1f, /*検知対象のレイヤー*/groundLayer);
        return hit.collider != null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * 1f);
    }
}
