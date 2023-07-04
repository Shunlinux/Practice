using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Chase : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float heightPriority = 0.5f;

    private void Update()
    {
        // プレイヤーの位置を取得
        Vector2 targetPosition = player.position;

        // 高さを優先的に合わせる
        //targetPosition.y = Mathf.Lerp(transform.position.y, targetPosition.y, heightPriority);

        // プレイヤーの方向に移動する
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}