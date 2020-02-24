using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour {

	public GameObject bulletPrefab;
	public int bulletAmount = 20;

	private List<GameObject> bullets;
	private static ObjectPoolingManager instance; 
	public static ObjectPoolingManager Instance{ get { return instance; } }

	// Use this for initialization
	void Awake () {
		instance = this;

		bullets = new List<GameObject> (bulletAmount);
		for (int i = 0; i < bulletAmount; i++) {
			GameObject prefabInstance = Instantiate (bulletPrefab);
			prefabInstance.transform.SetParent (transform);
			prefabInstance.SetActive (false);

			bullets.Add (prefabInstance);
		}
	}
	
	public GameObject GetBullet() {
		//loop through list of bullets -> retrieve inactive one.
		foreach (GameObject bullet in bullets) {
			if (!bullet.activeInHierarchy) {
				bullet.SetActive (true);
				return bullet;
			}
		}

		//if all bullets are active create another one
		GameObject prefabInstance = Instantiate (bulletPrefab);
		prefabInstance.transform.SetParent (transform);
		bullets.Add (prefabInstance);

		return prefabInstance;

	}
}
