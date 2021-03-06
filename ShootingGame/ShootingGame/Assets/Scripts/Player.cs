﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	protected Spaceship spaceship;

	//public float speed=5;
	//public GameObject bullet;

	void Update () 
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
		
		// 上・下
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 dir = (new Vector2 (x, y).normalized);


		// 移動する向きとスピードを代入する
		spaceship.Move (dir);
	}

	IEnumerator Start ()
	{
		spaceship = GetComponent<Spaceship> ();

		while (true) {
			// 弾をプレイヤーと同じ位置/角度で作成
			//Instantiate (bullet, transform.position, transform.rotation);
			spaceship.Shot(transform);
			GetComponent<AudioSource>().Play();

			// 0.05秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		string layer = LayerMask.LayerToName (c.gameObject.layer);

		if (layer == "E_Bullet") 
		{
			// 弾の削除
			Destroy(c.gameObject);

			// Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
			FindObjectOfType<Manager>().GameOver();
			
			// 爆発する
			spaceship.Explosion();
			
			// プレイヤーを削除
			Destroy (gameObject);
		}
		if (layer == "Enemy") 
		{
			// Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
			FindObjectOfType<Manager>().GameOver();

			// 爆発する
			spaceship.Explosion();
			
			// プレイヤーを削除
			Destroy (gameObject);
		}
	}

}
