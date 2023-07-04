using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ATK : MonoBehaviour
{
    //rigidboby用変数
    Rigidbody2D rigid2D;
    //攻撃のクールタイム
    public float atk_ct = 0.1f;
    //連続攻撃の受付時間
    public float atk_time = 0.5f;
    //代入用変数
    float atkCT;
    public int atkCount;
    float atkTimer;
    //[SerializeField] private GameObject player;
    [SerializeField] private GameObject playerAttackPrefab;
    public float attackDamage = 1f;
    int movex;
    Vector2 attackPos;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbobyのコンポーネント取得
        this.rigid2D = GetComponent<Rigidbody2D>();
        atkCT = -1f;
        atkCount = 0;
        atkTimer = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        //0で左1で右2で中央
        if(Input.GetMouseButtonUp(0) && atkCT < 0)
        {
            //atkCTに攻撃クールタイムを代入
            atkCT = atk_ct;
            //AttackCount()の処理を実行
            AttackCount();
        }

        //タイマーが０以下になるまで
        if(atkCT > 0)
        {
            //時間経過でタイマーをマイナス
            atkCT -= Time.deltaTime;
        }

        //タイマーが０以下になるまで
        if(atkTimer > 0)
        {
            //時間経過でタイマーをマイナス
            atkTimer -= Time.deltaTime;
        }
        else
        {
            //攻撃回数を０にする
            atkCount = 0;
        }

        /*P_ATKmove p_ATKmove = playerAttackPrefab.GetComponent<P_ATKmove>();
        atkJudge = p_ATKmove.atkJudge;
        if(atkJudge == true)
        {
            this.rigid2D.velocity = new Vector2(0, 0);
        }*/

        //Debug.Log(atkJudge);
    }

    void FixedUpdate()
    {
        //Debug.Log(atkTimer);
    }

    //攻撃回数カウンター
    void AttackCount()
    {
        //攻撃時は停止する rigid2D.velocity = new Vector2(0, 0);
        
        //攻撃回数を+1する
        atkCount += 1;
        //攻撃回数で判定
        switch(atkCount)
        {
            //攻撃回数が1,2,3回の時
            case 1:
            case 2:
            case 3:
                //
                atkTimer = atk_time;
                //共有変数取得用の変数season_conを宣言
                P_con_addF p_con;
                //オブジェクト”Plyer”を見つける
                GameObject player = GameObject.Find("Player");
                //p_conに”Plyer”のスクリプト”P_con”を代入
                p_con = player.GetComponent<P_con_addF>();
                //movexにP_con内の変数movexを代入
                movex = p_con.movex;
                //オブジェクト”OBird”を見つける
                Vector2 playerPos = this.transform.position;
                //作成位置を指定
                attackPos.x = playerPos.x + movex;
                attackPos.y = playerPos.y;
                //platerAttackをPlayerの座標に作成
                Instantiate(playerAttackPrefab, attackPos, Quaternion.identity);
                break;
            
            //それ以外
            default:
                break;
        }
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.right * 1f);
    }*/
}
