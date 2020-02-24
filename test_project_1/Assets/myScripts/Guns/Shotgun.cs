 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun {

	public int pellets = 8;
	public float ammo;
	public float spreadAngle;
	private float fireTimer = 0.0f;
	// Use this for initialization
	
	// Update is called once per frame

	void Start(){
        currentAmmo = initAmmo;
    }
	void Update () {
		fireTimer += Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && fireTimer > shotTimer) {
			
			fire ();
			fireTimer = 0;
		}
	}

	public override void fire(){
		for (int i = 0; i < pellets; i++) {
			if (currentAmmo > 0) {
				GameObject bulletObject = BulletPoolManager.Instance.GetBullet ();
				//pass player position to bulletObject
				bulletObject.transform.position = gunBarrel.transform.position + new Vector3 (0, 0, .2f);
				bulletObject.transform.rotation = player.transform.rotation;
				bulletObject.transform.Rotate (0.0f, Random.Range (-spreadAngle, spreadAngle), 0.0f);
                
            }

		}
        currentAmmo--;
    }
}
