using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ATKmove : MonoBehaviour
{
    public float judgeTime;
    public bool atkJudge;

    // Start is called before the first frame update
    void Start()
    {
        judgeTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        judgeTime -= Time.deltaTime;
        //Debug.Log(time);
        if(judgeTime < 0)
        {
            atkJudge = false;
            //攻撃オブジェクトの破棄
            Destroy(this.gameObject);
        }
        //Debug.Log(atkJudge);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        atkJudge = true;
        //攻撃オブジェクトの破棄
        //Destroy(this.gameObject);
    }
}
