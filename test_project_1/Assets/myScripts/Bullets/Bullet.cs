using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 8f;
	public float lifeDuration = 2f;
	public int damage; 

	private float lifeTimer;
	private bool shotByPlayer = false;
	public bool ShotByPlayer { get {return shotByPlayer;} set {shotByPlayer = value;}}

	// Use this for initialization
	void OnEnable () {
		lifeTimer = lifeDuration;
	}
	
	// Update is called once per frame
	void Update () {
		//moving bullet forward
		transform.position += transform.forward * speed * Time.deltaTime;
		//countDown lifeTimer
		lifeTimer -= Time.deltaTime;
		if (lifeTimer <= 0) {
			//OLDDestroy (gameObject);
			gameObject.SetActive(false);
		}
	}
    void OnTriggerEnter(Collider otherCollider)
    {
        


    }

}
