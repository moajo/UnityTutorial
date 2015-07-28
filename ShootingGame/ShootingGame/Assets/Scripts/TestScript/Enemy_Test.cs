using UnityEngine;
using System.Collections;

public class Enemy_Test : Spaceship_Test{

	// Use this for initialization
	IEnumerator Start () 
	{
		Move (transform.up * -1);

		if (!canShot)
			yield break;
		
		while (true) {
			
			Shot();
			
			// shotDelay秒待つ
			yield return new WaitForSeconds (shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
