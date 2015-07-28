using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship_Test : MonoBehaviour {

	public float speed;

	// 弾を撃つ間隔
	public float shotDelay;
	
	// 弾のPrefab
	public GameObject bullet;

	//弾を発車する位置のリスト
	public GameObject[] shotPositionList;

	public bool canShot=true;
	
	// 弾の作成
	public void Shot ()
	{
		for (int i = 0; i < shotPositionList.Length; i++)
		{
			var trf=shotPositionList[i].transform;
			Instantiate(bullet,trf.position,trf.rotation);
		}
	}
	
	// 機体の移動
	public void Move (Vector2 direction)
	{
		GetComponent<Rigidbody2D> ().velocity = direction * speed;
	}
}
