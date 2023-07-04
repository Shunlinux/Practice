using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Drag : MonoBehaviour
{
    Rigidbody2D rigid2D;
	public float waterDrag = 3.0f;
	public float defaultDrag = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
		rigid2D = gameObject.GetComponent<Rigidbody2D>();
		defaultDrag = rigid2D.drag;
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Water")
        {
			// 水の中の抵抗をセット
			this.rigid2D.drag = waterDrag;
		}
	}

	void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Water")
        {
			// 通常の抵抗をセット
			this.rigid2D.drag = defaultDrag;
		}
	}
}
