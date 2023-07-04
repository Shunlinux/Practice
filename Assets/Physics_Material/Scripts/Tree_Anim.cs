using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Anim : MonoBehaviour
{
    //季節の判定変数seasonを宣言
    private int season;
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
        //共有変数取得用の変数switch_seasonを宣言
        Swich_Season switch_season;
        //オブジェクト”Tree”を見つける
        GameObject obj = GameObject.Find("Tree");
        //switch_seasonに”Tree”のスクリプト”Swich_Season”を代入
        switch_season = obj.GetComponent<Swich_Season>();
        //seasonにswitch_season内の変数seasonを代入
        season = switch_season.season;
        // アニメーション切り替え
        animator.SetInteger("season", season);
        //()の中身を表示
        //Debug.Log(season);
    }
}
