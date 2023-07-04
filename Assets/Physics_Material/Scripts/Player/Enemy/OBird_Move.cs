using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBird_Move : MonoBehaviour
{
    //物理を使う
    Rigidbody2D rigid2D;
    //addForceで動かす
    public float addForce = 1.0f;
    public float maxmoveForce = 1.0f;
    /*
    // x軸方向の移動範囲の最小値
    [SerializeField] float _minX = -1;
    // x軸方向の移動範囲の最大値
    [SerializeField] float _maxX = 1;
    */

    // Start is called before the first frame update
    void Start()
    {
        //物理の適応
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //speedxに現在速度を代入
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //動きの速度範囲を設定
        speedx = Mathf.Clamp(speedx, 0, maxmoveForce);
        //OBrid_Posを軸にする
        //オブジェクト”OBird_Pos”を見つける
        Vector2 obPos = GameObject.Find("OBird_Pos").transform.position;
        //"OBird"の座標取得
        Vector2 pos = this.transform.position;
        //範囲を越えたら急速に止まる
        if(pos.x <= obPos.x - 1)
        {
            addForce = 1;
        }
        if(pos.x >= obPos.x + 1)
        {
            addForce = -1;
        }
        /*
        //特定範囲から出られない
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        transform.position = pos;
        */
        this.rigid2D.AddForce(transform.right * addForce);

        //Debug.Log(speedx);
    }
}
