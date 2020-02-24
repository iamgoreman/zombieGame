using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun {

	private float fireTimer = 0.0f;
	public float ammo;
	// Use this for initialization

	
	// Update is called once per frame
	void Start(){
        currentAmmo = initAmmo;
    }

	void Update () {
		fireTimer += Time.deltaTime;
		if (Input.GetMouseButton (0) && fireTimer > shotTimer) {
			//Debug.Log ("Rifle");
			fire ();
			fireTimer = 0;
		}
	}

	public override void fire(){

		/*if (ammo > 0) {
				ammo--;*/
		//Old bullet creation
		//GameObject bulletObject = Instantiate(bulletPrefab);


		if (currentAmmo > 0) {
			GameObject bulletObject = BulletPoolManager.Instance.GetBullet ();
			//pass player position to bulletObject
			bulletObject.transform.position = gunBarrel.transform.position + new Vector3(0,0,.2f);
			bulletObject.transform.rotation = player.transform.rotation;
            currentAmmo--;
        }



		//bulletObject.transform.forward = gunBarrel.transform.forward;

		//} 

	}
}
