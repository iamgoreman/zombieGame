using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public int health=3;
	public int damage= 5;
	private bool killed = false;
	public bool Killed  { get { return killed; }}
	public GameObject player;
	private NavMeshAgent agent;
    private Animator myAnim;
    public float attackDist = 3;

	void Start(){
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (player.transform.position);
        myAnim = GetComponent<Animator>();
        myAnim.speed = 1.5f;
	}

	void Update(){
		agent.SetDestination (player.transform.position);
        Debug.DrawRay(this.transform.position, player.transform.position);
        myAnim.SetBool("Walking", true);


        if (Vector3.Distance(transform.position, player.transform.position) <= attackDist)
        {
            myAnim.SetBool("Walking", false);
            myAnim.SetBool("Slapping", true);
        }

        else
        {
            myAnim.SetBool("Walking", true);
            myAnim.SetBool("Slapping", false);
        }


    }
	void OnTriggerEnter(Collider otherCollider) {
		if (otherCollider.GetComponent<Bullet> () != null) {
			Bullet bullet = otherCollider.GetComponent<Bullet> ();
				health -= bullet.damage;
				bullet.gameObject.SetActive (false);
				if (health <= 0) {
					if (killed == false) {

						//Destroy (gameObject);
						killed = true;
						OnKill ();
					}
				}
			

		}

        
	}



	protected virtual void OnKill() {
		this.enabled = false;
        agent.enabled = false;
        myAnim.SetBool("Walking", false);
        myAnim.SetBool("Slapping", false);
        myAnim.SetBool("Dead", true);
    }
		

}
