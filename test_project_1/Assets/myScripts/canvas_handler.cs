using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvas_handler : MonoBehaviour {

    public List<GameObject> gunArray;
    private Gun selectedWeapon;
    public Text currentAmmo;
    public Text totalAmmo;
    public List<GameObject> healthBar;
    public Player player;
    private int tick = 0;

    // Use this for initialization
    void Start () {
        foreach (GameObject gun in gunArray) {
            if (gun.activeInHierarchy) {
                selectedWeapon = gun.GetComponent<Gun>();
            }
        }

        totalAmmo.text = selectedWeapon.GetComponent<Gun>().maxAmmo.ToString();
        currentAmmo.text = selectedWeapon.GetComponent<Gun>().currentAmmo.ToString();

        for (int i = player.health - 1; i > -1; i--)
        {
            healthBar[i].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {

        int i = 4;
            do
            {
            
                healthBar[i].SetActive(false);
                if (i < player.health)
                {
                    healthBar[i].SetActive(true);
                }
                i--;
            } while (i > 0);

            
        
        foreach (GameObject gun in gunArray)
        {
            if (gun.activeInHierarchy)
            {
                selectedWeapon = gun.GetComponent<Gun>();
            }
        }

        totalAmmo.text = selectedWeapon.GetComponent<Gun>().maxAmmo.ToString();
        currentAmmo.text = selectedWeapon.GetComponent<Gun>().currentAmmo.ToString();
    }
}
