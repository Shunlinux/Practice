using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBird_con : MonoBehaviour
{
    Vector2 pos;
    /*
    常に空を飛んでいる→重力無し
    決まったルートを徘徊する→範囲を越えたら反転
    一部の固体はプレイヤーの頭上をつきまとう→Raycastで判定?
　　追尾範囲はクマと同様(画面半分を半径に)
    */

    //当たり判定アリ
    //verosityで動かす(速度は固定)
    //
    //何かに当たったら速度を急激に下げる、反対へ
    //"OBird_Pos"を基準に範囲を決める

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //オブジェクト”Plyer”を見つける
        GameObject player = GameObject.Find("Player");
        Vector2 playerPos = player.transform.position;
        //作成位置を指定
        pos.x = playerPos.x;
        pos.y = playerPos.y;
    }
}
