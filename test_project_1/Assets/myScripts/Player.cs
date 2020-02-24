using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int health = 5;
    public float speed = 15f;
    public float moveGravity;
    public float stillGravity;
    public float jumpHeight = 15f;
    private bool invincible = false;

    private Rigidbody myRB;

    private Vector3 moveInput;
    private Vector3 moveVel;
    [SerializeField]
    private GameObject model;

    private bool grounded;
    private bool lightSwitch = false;
    public GameObject flashlight;


    // Use this for initialization
    void Start() {
        myRB = GetComponent<Rigidbody>();
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        moveVel = moveInput * speed * Time.deltaTime;

        //if(Input.GetKeyDown(KeyCode.Space) && grounded){

        //	myRB.AddForce(new Vector3(0,jumpHeight,0),ForceMode.Impulse);
        //	grounded = false;
        //}

        if (Input.GetKeyDown(KeyCode.F)) {
            toggleFlashlight();
        }
    }

    void FixedUpdate() {

        transform.position += moveVel;
    }

    void OnCollisionStay(Collision col) {

        if (col.gameObject.tag == ("Road") && grounded == false) {

            grounded = true;
        }
    }

    void toggleFlashlight() {

        if (lightSwitch) {
            flashlight.SetActive(false);
            lightSwitch = !lightSwitch;
        }

        else {
            flashlight.SetActive(true);
            lightSwitch = !lightSwitch;
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Enemy>() != null)
        {
            if (invincible != true) {
                Debug.Log("slap");
                Enemy enemy = otherCollider.GetComponent<Enemy>();
                health -= enemy.damage;
                Debug.Log(health);
                StartCoroutine(InvincibleFrames());
            }




        }
    }
    private IEnumerator InvincibleFrames() {
        invincible = true;
        Debug.Log("start");
        for (float i = 0.00f; i < 1.5f; i+= 0.10f)
        {
            if (GetComponent<Renderer>().enabled == true)
            {
                GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GetComponent<Renderer>().enabled = true;
            }
            yield return new WaitForSeconds(.10f);

        }
        invincible = false;
        GetComponent<Renderer>().enabled = true;
        Debug.Log("finish");
    }
}
