using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {
	private float fireTimer = 0.0f;
	// Use this for initialization
	void Start(){
		currentAmmo = initAmmo;
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && fireTimer > shotTimer ) {
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
            //GenerateTracer (bulletObject.transform);

            //bulletObject.transform.forward = gunBarrel.transform.forward;
            currentAmmo--;
		}


		//} 

	}

//	void GenerateTracer(Transform bullet){
//		GameObject lineGenerator = Instantiate (tracerPreFab);
//		LineRenderer tRend = lineGenerator.GetComponent<LineRenderer> ();
//
//		tRend.SetPosition (0, gunBarrel.transform.position);
//		tRend.SetPosition (1, bullet.position);
//
//		Destroy (lineGenerator,.5f);
//	}
}
