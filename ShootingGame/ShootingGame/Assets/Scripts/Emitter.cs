﻿using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	// Waveプレハブを格納する
	public GameObject[] wavelist;
	
	// 現在のWave
	private int currentWaveIndex;
	// Managerコンポーネント
	private Manager manager;

	IEnumerator Start ()
	{
		
		// Waveが存在しなければコルーチンを終了する
		if (wavelist.Length == 0) {
			yield break;
		}
		// Managerコンポーネントをシーン内から探して取得する
		manager = FindObjectOfType<Manager> ();

		
		while (true) {
			// タイトル表示中は待機
			while(!manager.IsPlaying) {
				yield return new WaitForEndOfFrame ();
			}
			
			// Waveを作成する
			GameObject wave = (GameObject)Instantiate (wavelist [currentWaveIndex], transform.position, Quaternion.identity);
			
			// WaveをEmitterの子要素にする
			wave.transform.parent = transform;
			
			// Waveの子要素のEnemyが全て削除されるまで待機する
			while (wave.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}
			
			// Waveの削除
			Destroy (wave);
			
			// 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
			if (wavelist.Length <= ++currentWaveIndex) {
				currentWaveIndex = 0;
			}
			
		}
	}


	void Update ()
	{
	
	}
}
