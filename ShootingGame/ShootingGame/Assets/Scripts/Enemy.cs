using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () 
	{
		spaceship=GetComponent<Spaceship>();
		spaceship.Move (transform.up * -1);

		if (!spaceship.canShot)
			yield break;

		while (true) {
			
			// 子要素を全て取得する
			for (int i = 0; i < transform.childCount; i++) {
				
				Transform shotPosition = transform.GetChild(i);
				shotPosition.transform.position=transform.position;
				
				// ShotPositionの位置/角度で弾を撃つ
				spaceship.Shot (shotPosition);
			}
			
			// shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
