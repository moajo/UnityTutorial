﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

	public float speed=10;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
