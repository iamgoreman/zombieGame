using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour {

	public GameObject bulletPrefab;
	public int initBulletAmount = 20;

	private List<GameObject> Bullets;

	public static BulletPoolManager instance;
	public static BulletPoolManager Instance{ get { return instance; } }
	// Use this for initialization
	void Awake(){
		
		instance = this;

		Bullets = new List<GameObject> (initBulletAmount);
		for (int i = 0; i < initBulletAmount; i++) {
			GameObject prefabInstance = Instantiate (bulletPrefab);

			prefabInstance.transform.SetParent (transform);
			prefabInstance.SetActive (false);
			//Debug.Log (prefabInstance);
			Bullets.Add (prefabInstance);
		
		}
	}

	public GameObject GetBullet(){
		foreach (GameObject bullet in Bullets) {
			if (!bullet.activeInHierarchy) {
				//Debug.Log (bullet);
				bullet.SetActive (true);
				bullet.GetComponent<Bullet> ();
				return bullet;
				}
		
			}
			
		GameObject prefabInstance = Instantiate (bulletPrefab);

		prefabInstance.transform.SetParent (transform);
		prefabInstance.SetActive (true);
		prefabInstance.GetComponent<Bullet> ();
		Bullets.Add (prefabInstance);

		return prefabInstance;	
		}
		
	}

