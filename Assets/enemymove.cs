﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour {

	private float speed=0.2f;
	private bool MoveRight;

	// Use this for initialization
	void Update () {
		// Use this for initialization
		if(MoveRight) {
			transform.Translate(2* Time.deltaTime * speed, 0,0);
			transform.localScale= new Vector2 (1,1);
 		}
		else{
			transform.Translate(-2* Time.deltaTime * speed, 0,0);
			transform.localScale= new Vector2 (-1,1);
		}
	}
	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.CompareTag("limit")){

			if (MoveRight){
				MoveRight = false;
			}
			else{
				MoveRight = true;
			}	
		}
	}
}