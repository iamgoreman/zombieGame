using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {
	public Quaternion startMarker;
	public Quaternion endMarker;
	private Vector3 start = new Vector3(0,40,0);
	private Vector3 end = new Vector3(0,-40,0);
	private bool dirc = false;
	private bool gate = false;
	private float attackTimer = 1.5f;

	// Movement speed in units per second.
	public float speed = .01F;


	// Use this for initialization
	void Start(){
		startMarker = Quaternion.Euler (start); 
		endMarker =  Quaternion.Euler (end);
	}
	
	// Update is called once per frame
	void Update () {
		attackTimer -= Time.deltaTime;
		if (Input.GetKey(KeyCode.Space) && attackTimer<=0) {
			gate = true;

		} 
		if (dirc & gate) {
			transform.rotation = Quaternion.Lerp (startMarker, endMarker, Time.deltaTime * speed);
			dirc = !dirc;
			gate = false;
			attackTimer = 1.5f;
		}
//		
		if(!dirc & gate){
			transform.rotation = Quaternion.Lerp (endMarker, startMarker, Time.deltaTime * speed);
			dirc = !dirc;
			attackTimer = 1.5f;
		}
	}
}

