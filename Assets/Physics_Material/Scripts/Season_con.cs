using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Season_con : MonoBehaviour
{
    //リスト型で格納すべきかも
    //seasonに代入する文字列を宣言
    string[] season = {"Spring", "Summer", "Autumn", "Winter"};
    //共有する変数seasonIndexを宣言
    public int seasonIndex;
    //現在の季節を格納する変数seasonを宣言
    string nowSeason;

    // Start is called before the first frame update
    void Start()
    {
        //seasonIndexを０にする
        seasonIndex = 0;
        //nowSeasonにseasonIndexに対応したseason内の文字列を代入する
        nowSeason = season[seasonIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //もしCキーが押されたら
        if(Input.GetKeyUp(KeyCode.C))
        {
            //もし接地しているなら
            //関数SwitchChange()の処理を実行
            SwitchChange();

            //してないなら
            //関数SwitchChange()の処理を実行
            //関数SwitchChange()の処理を実行できなくする
        }
        //Debug.Log(seasonIndex);
    }

    void SwitchChange()
    {
        //seasonIndexに+1して、season内の文字列数(4つ)で割った余りを代入
        seasonIndex = (seasonIndex + 1) % season.Length;
        //nowSeasonにseasonIndexに対応したseason内の文字列を代入する
        nowSeason = season[seasonIndex];
        //Debug.Log(seasonIndex);
    }

    private void OnGUI()
    {
        //今の季節を表示する変数seasonNameを宣言
        string seasonName = season[seasonIndex];
        //UI用のGUIを使用する
        //左上からx10,y10の位置に横幅200,縦幅20の文章「”Current Season: ” + seasonName」を表示する
        GUI.Label(new Rect(10f, 10f, 200f, 20f), "Current Season: " + seasonName);
    }
}