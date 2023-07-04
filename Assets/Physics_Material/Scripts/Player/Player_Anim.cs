using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    //攻撃回数の判定変数atkCountを宣言
    private int atkCount;
    // アニメーターコンポーネント取得用変数を宣言
    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        // アニメーターコンポーネント取得
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //共有変数取得用の変数plyer_atkを宣言
        Player_ATK plyer_atk;
        //オブジェクト" "を見つける
        GameObject obj = GameObject.Find("Player");
        //plyer_atkに”Plyer”のスクリプト”Plyer_ATK”を代入
        plyer_atk = obj.GetComponent<Player_ATK>();
        //seasonにswitch_season内の変数seasonを代入
        atkCount = plyer_atk.atkCount;
        // アニメーション切り替え
        animator.SetInteger("ATK_Count", atkCount);
    }
}
