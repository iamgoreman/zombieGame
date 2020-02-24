using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject gunBarrel;
	public Player player;
	public int maxAmmo;
    public int currentAmmo;
	public int initAmmo;
	public GameObject tracerPreFab;

	public float shotTimer;

    public virtual void fire() {
        
    }
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		}
	}

