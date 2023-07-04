using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_con_Vector : MonoBehaviour
{
    //物理を使う
    Rigidbody2D rigid2D;
    //動きの向き
    int moveX;
    //歩きの速度
    float warkSpeed = 2f;
    //慣性の秒数
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //物理の適応
        this.rigid2D = GetComponent<Rigidbody2D>();
        moveX = 0;
        timer = -1;

    }

    // Update is called once per frame
    void Update()
    {
        //Aキーを押している間
        if (Input.GetKey(KeyCode.A))
        {
            timer = -1f;
            moveX = -1;
            rigid2D.velocity = new Vector2(moveX * warkSpeed, rigid2D.velocity.y);
            
        }
        //Dキーを押している間
        if (Input.GetKey(KeyCode.D))
        {
            timer = -1;
            moveX = 1;
            rigid2D.velocity = new Vector2(moveX * warkSpeed, rigid2D.velocity.y);
        }

        //Aキーを離したら
        if(Input.GetKeyUp(KeyCode.A))
        {
            moveX = 0;
            timer = 0.3f;
            //Debug.Log("a");
        }

        //Dキーを離したら
        if(Input.GetKeyUp(KeyCode.D))
        {
            moveX = 0;
            timer = 0.7f;
            //Debug.Log("a");
        }
        Debug.Log(timer);

        if(timer > 0)
        {
            timer -= Time.deltaTime;
            this.rigid2D.velocity = new Vector2(moveX * warkSpeed, rigid2D.velocity.y);
            
        }
    }
}
