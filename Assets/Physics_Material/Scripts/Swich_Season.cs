using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich_Season : MonoBehaviour
{
    //共有する変数seasonを宣言
    public int season;

    // Start is called before the first frame update
    void Start()
    {
        //seasonを０にする
        season = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //共有変数取得用の変数season_conを宣言
        Season_con season_con;
        //オブジェクト”Plyer”を見つける
        GameObject obj = GameObject.Find("Player");
        //switch_seasonに”Plyer”のスクリプト”Swich_Season”を代入
        season_con = obj.GetComponent<Season_con>();
        //seasonにswitch_season内の変数seasonを代入
        season = season_con.seasonIndex;
        //Debug.Log(season);
    }
}