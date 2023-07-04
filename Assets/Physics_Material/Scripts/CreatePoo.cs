using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoo : MonoBehaviour
{
    public GameObject PooPrefab;
    Vector2 pos;
    public float ct = 3;
    float countCT;

    // Start is called before the first frame update
    void Start()
    {
        countCT = ct;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        countCT -= 0.01f;
        if(countCT <= 0)
        {
            //オブジェクト”OBird”を見つける
            Vector2 obPos = GameObject.Find("OBird").transform.position;
            //作成位置を指定
            pos.x = obPos.x;
            pos.y = obPos.y - 1;
            //作成
            Instantiate(PooPrefab, pos, Quaternion.identity);
            countCT = ct;
        }

        //Debug.Log(countCT);
    }
}
