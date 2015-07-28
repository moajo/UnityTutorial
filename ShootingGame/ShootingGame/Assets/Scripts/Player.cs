using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed=5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
		
		// 上・下
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 dir = (new Vector2 (x, y).normalized);


		// 移動する向きとスピードを代入する
		GetComponent<Rigidbody2D>().velocity = dir * speed;
	}
}
