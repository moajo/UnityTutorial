﻿using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour 
{


	public float speed = 0.1f;


	// Use this for initialization
	void Start () {
	
	}
	
	void Update ()
	{
		// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		float y = Mathf.Repeat (Time.time * speed, 1);
		
		// Yの値がずれていくオフセットを作成
		Vector2 offset = new Vector2 (0, y);

		GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

	}
}
