﻿using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	// Playerプレハブ
	public GameObject player;
	
	// タイトル
	private GameObject title;
	
	void Start ()
	{
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");
	}
	
	void Update ()
	{
		if (!IsPlaying&& Input.GetKeyDown (KeyCode.X)) 
			GameStart ();
		
	}

	void GameStart ()
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.SetActive (false);
		Instantiate (player, player.transform.position, player.transform.rotation);
	}
	
	public void GameOver ()
	{
		// ハイスコアの保存
		FindObjectOfType<Score>().Save();
		// ゲームオーバー時に、タイトルを表示する
		title.SetActive (true);
	}
	
	public bool IsPlaying
	{
		get{return title.activeSelf == false;}
	}
}
