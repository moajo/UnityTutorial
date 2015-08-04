using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {
	
	public float speed;

	// 弾を撃つ間隔
	public float shotDelay;
	
	// 弾のPrefab
	public GameObject bullet;

	public bool canShot;

	public GameObject explosion;

	//画面外移動を制限するかどうか
	public bool IsPlayer=false;

	public void Explosion()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	// 弾の作成
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}
	
	// 機体の移動
	public void Move (Vector2 direction)
	{
		if (IsPlayer) 
		{
			// 画面左下のワールド座標をビューポートから取得
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
			
			// 画面右上のワールド座標をビューポートから取得
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
			
			// プレイヤーの座標を取得
			Vector2 pos = transform.position;
			
			// 移動量を加える
			pos += direction  * speed * Time.deltaTime;
			
			// プレイヤーの位置が画面内に収まるように制限をかける
			pos.x = Mathf.Clamp (pos.x, min.x, max.x);
			pos.y = Mathf.Clamp (pos.y, min.y, max.y);
			
			// 制限をかけた値をプレイヤーの位置とする
			transform.position = pos;
		} 
		else 
		{
			GetComponent<Rigidbody2D> ().velocity = direction * speed;
		}
	}
}
