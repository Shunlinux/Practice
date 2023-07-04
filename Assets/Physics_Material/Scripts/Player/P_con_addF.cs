using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_con_addF : MonoBehaviour
{
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private LayerMask groundLayer;
    //初速
    public float firstSpeed;
    //加速
    public float accelSpeed;
    //初速の力
    float fristForce;
    //加速の力
    float accelForce;
    //
    float speedx;
    public float maxSpeedx;
    //物理を使う
    Rigidbody2D rigid2D;
    //走りの倍率
    float run = 1.5f;
    //走りの力
    float runForce;
    //動きの向き
    public int movex;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //物理の適応
        this.rigid2D = GetComponent<Rigidbody2D>();
        fristForce = firstSpeed;
        accelForce = accelSpeed;
        this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //speedxに現在速度を代入
        speedx = this.rigid2D.velocity.x;

        /*旧左右移動
          if (speedx == 0 && Input.GetKeyDown(KeyCode.A))
         {
             movex = -1;
             rigid2D.AddForce(transform.right * fristForce * movex * runForce, ForceMode2D.Impulse);

         }

         if (speedx == 0 && Input.GetKeyDown(KeyCode.D))
         {
             movex = 1;
             rigid2D.AddForce(transform.right * fristForce * movex * runForce, ForceMode2D.Impulse);

         }
        */
        //左右移動
        int key = 0;
        if (Input.GetKeyDown(KeyCode.D)) key = 1;
        if (Input.GetKeyDown(KeyCode.A)) key = -1;
        //Aキーを押している間
        if (speedx > -maxSpeedx * runForce && Input.GetKey(KeyCode.A))
        {
            movex = -1;
            rigid2D.AddForce(transform.right * accelForce * movex * runForce, ForceMode2D.Force);
            this.animator.SetTrigger("WalkTrigger");

        }
        //Dキーを押している間
        if (speedx < maxSpeedx * runForce && Input.GetKey(KeyCode.D))
        {
            movex = 1;
            rigid2D.AddForce(transform.right * accelForce * movex * runForce, ForceMode2D.Force);
            this.animator.SetTrigger("WalkTrigger");
        }

        //左シフトが押されている間
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //走りの力を
            runForce = run;
        }
        else
        {
            runForce = 1;
        }
        if (key != 0)
        {
            //左右に動いたら反転
            transform.localScale = new Vector3(key, 1, 1);
        }
        Debug.Log(speedx);

        //落ちたら元の場所に戻る
        if (transform.position.y < -20)
        {
            SceneManager.LoadScene("GameScene");
        }
        //ジャンプコマンド
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
               
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up *jumpPower,ForceMode2D.Impulse);
        }

    }
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(/*位置*/transform.position, /*半径*/0.5f, /*方向*/Vector2.down, /*長さ*/1f, /*検知対象のレイヤー*/groundLayer);
        return hit.collider != null;
    }
}

