using UnityEngine;
using System.Collections;

public class Player_Test : Spaceship_Test {
	// Use this for initialization
	IEnumerator Start ()
	{
		while (true)
		{
			// 弾をプレイヤーと同じ位置/角度で作成
			Shot();
			
			// 0.05秒待つ
			yield return new WaitForSeconds (shotDelay);
		}
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
		Move (dir);
	
	}
}
