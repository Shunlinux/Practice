using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //

public class P_con : MonoBehaviour
{
    //物理を使う
    Rigidbody2D rigid2D;
    //入力時点の速度
    float fristForce;
    //動きの加速度
    public float accelSpeed = 0.1f;
    //加速の合計
    float accelForce;
    //走りの力(歩きの速度の何倍か？)
    public float runSpeed = 1.5f;
    //走りの力
    float runForce;
    //現在速度
    float speedx;
    //最大速度
    public float maxSpeedx = 5;
    //動きの向き
    public int movex;

    // Start is called before the first frame update
    void Start()
    {
        //物理の適応
        this.rigid2D = GetComponent<Rigidbody2D>();

        movex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //speedxに現在速度を代入
        speedx = this.rigid2D.velocity.x;

        //Aキーを押した
        if (Input.GetKeyDown(KeyCode.A))
        {
            accelForce = 0;
            if(speedx == 0)
            {
                fristForce = -2;
            }
            else
            {
                fristForce = speedx;
            }
        }
        //Aキーを押した
        if (Input.GetKeyDown(KeyCode.D))
        {
            accelForce = 0;
            if(speedx == 0)
            {
                fristForce = 2;
            }
            else
            {
                fristForce = speedx;
            }
        }

        //Aキーを押している間
        if (Input.GetKey(KeyCode.A))
        {
            movex = -1;
            if(speedx > -maxSpeedx * runForce)
            {
                accelForce += movex * accelSpeed;
                this.rigid2D.velocity = new Vector2(fristForce + accelForce * runForce, this.rigid2D.velocity.y);
            }
        }
        //Dキーを押している間
        if (Input.GetKey(KeyCode.D))
        {
            movex = 1;
            if(speedx < maxSpeedx * runForce)
            {
                accelForce += movex * accelSpeed;
                this.rigid2D.velocity = new Vector2(fristForce + accelForce * runForce, this.rigid2D.velocity.y);
            }
        }

        //左シフトが押されている間
        if(Input.GetKey(KeyCode.LeftShift))
        {
            //走りの力を
            runForce = runSpeed;
        }
        else
        {
            runForce = 1;
        }

        Debug.Log(fristForce);

    }

   
    void FixedUpdate()
    {
        
    }
}
