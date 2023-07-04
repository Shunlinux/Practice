using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_hpCon : MonoBehaviour
{
    float damaged;
    public float HP = 10;
    //P攻撃にヒットしたかの判定
    //攻撃されたらHPを減らす
    //HP0なら破壊
    //攻撃されたらノックバック

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            //攻撃オブジェクトの破棄
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerAttack")
        {
            //共有変数取得用の変数season_conを宣言
                Player_ATK p_atk;
                //オブジェクト”Plyer”を見つける
                GameObject player = GameObject.Find("Player");
                //p_conに”Plyer”のスクリプト”P_con”を代入
                p_atk = player.GetComponent<Player_ATK>();
                //movexにP_con内の変数movexを代入
                damaged = p_atk.attackDamage;
                HP -= damaged;
            //ダメージ量を受け取る
            //HPからダメージ分減らす
            Debug.Log("エネミーHP"+HP);
        }
    }
}
