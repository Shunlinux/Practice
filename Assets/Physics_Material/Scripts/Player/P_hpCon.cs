using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_hpCon : MonoBehaviour
{
    public float HP;
    //E攻撃にヒットしたかの判定
    //Eにヒットしたかの判定
    //攻撃されたらHPを減らす
    //HP0なら破壊
    //攻撃されたらノックバック

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyAttack")
        {
            //共有変数取得用の変数season_conを宣言
            ATK_Damage atkDamage;
            //オブジェクト”Plyer”を見つける
            GameObject enemyAttack = collision.gameObject;
            //p_conに”Plyer”のスクリプト”P_con”を代入
            atkDamage = enemyAttack.GetComponent<ATK_Damage>();
            //movexにP_con内の変数movexを代入
            float damaged = atkDamage.attackDamage;
            HP -= damaged;
            //ダメージ量を受け取る
            //HPからダメージ分減らす
            Debug.Log("プレイヤーHP"+HP);
        }
    }
}
