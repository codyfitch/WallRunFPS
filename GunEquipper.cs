using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour {

    public static string activeWeaponType;

    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    public GameObject sniperRifle;
    public GameObject sawedOff;
    public GameObject subMachineGun;
    public GameObject pistol_pickup;
    public GameObject assaultRifle_pickup;
    public GameObject shotgun_pickup;
    public GameObject sniperRifle_pickup;
    public GameObject sawedOff_pickup;
    public GameObject subMachineGun_pickup;
    public GameObject arorb;
    public GameObject shotgunorb;
    public GameObject sniperorb;
    public GameObject sawedofforb;
    public GameObject smgorb;
    private bool arActive = false;
    private bool shotgunActive = false;
    private bool sniperActive = false;
    private bool sawedoffActive = false;
    private bool smgActive = false;



    GameObject activeGun;

  
	// Use this for initialization
	void Start ()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;

        ////////////////////////////////Randomly Spawn Weapons on map/////////////////////////////////
        Vector3 position1 = new Vector3(Random.Range(-73.0f, 94.0f), 0, Random.Range(-70.0f, 111.0f));
        Vector3 position2 = new Vector3(Random.Range(-73.0f, 94.0f), 0, Random.Range(-70.0f, 111.0f));
        Vector3 position3 = new Vector3(Random.Range(-73.0f, 94.0f), 0, Random.Range(-70.0f, 111.0f));
        Vector3 position4 = new Vector3(Random.Range(-73.0f, 94.0f), 0, Random.Range(-70.0f, 111.0f));
        Vector3 position5 = new Vector3(Random.Range(-73.0f, 94.0f), 0, Random.Range(-70.0f, 111.0f));

        //Spawn Assault Rifle in random location
        Instantiate(assaultRifle_pickup, position1, Quaternion.identity);

        //Spawn Shotgun in random location
        Instantiate(shotgun_pickup, position2, Quaternion.identity);

        //Spawn Sniper Rifle in random location
        Instantiate(sniperRifle_pickup, position3, Quaternion.identity);

        //Spawn Sawed Off in random location
        Instantiate(sawedOff_pickup, position4, Quaternion.identity);

        //Spawn Sub Machine Gun in random location
        Instantiate(subMachineGun_pickup, position5, Quaternion.identity);
        /////////////////////////////////////////////////////////////////////////////////////////////
	}

    //When player runs over gun, they pick it up, orb disappears, and gun is active for player
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "arorb")
        {
            arorb = GameObject.FindWithTag("arorb");
            arorb.SetActive(false);
            assaultRifle.SetActive(true);
            arActive = true;
        } else if (col.gameObject.tag == "shotgunorb")
        {
            shotgunorb = GameObject.FindWithTag("shotgunorb");
            shotgunorb.SetActive(false);
            shotgun.SetActive(true);
            shotgunActive = true;
        } else if (col.gameObject.tag == "sniperorb")
        {
            sniperorb = GameObject.FindWithTag("sniperorb");
            sniperorb.SetActive(false);
            sniperRifle.SetActive(true);
            sniperActive = true;
        } else if (col.gameObject.tag == "sawedofforb")
        {
            sawedofforb = GameObject.FindWithTag("sawedofforb");
            sawedofforb.SetActive(false);
            sawedOff.SetActive(true);
            sawedoffActive = true;
        } else if (col.gameObject.tag == "smgorb")
        {
            smgorb = GameObject.FindWithTag("smgorb");
            smgorb.SetActive(false);
            subMachineGun.SetActive(true);
            smgActive = true;
        }
    }

    //switch weapons script
    void Update ()
    {
		if(Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;         

        }
        if (arActive == true)
        {
            if (Input.GetKeyDown("2"))
            {
                loadWeapon(assaultRifle);
                activeWeaponType = Constants.AssaultRifle;
            }
        }
        if (shotgunActive == true)
        {
            if (Input.GetKeyDown("3"))
            {
                loadWeapon(shotgun);
                activeWeaponType = Constants.Shotgun;

            }
        }
        if (sniperActive == true) { 
            if (Input.GetKeyDown("4"))
            {
                loadWeapon(sniperRifle);
                activeWeaponType = Constants.SniperRifle;
            }
        }
        if (sawedoffActive == true)
        {
            if (Input.GetKeyDown("5"))
            {
                loadWeapon(sawedOff);
                activeWeaponType = Constants.SawedOff;
            }
        }
        if (smgActive == true)
        {
            if (Input.GetKeyDown("6"))
            {
                loadWeapon(subMachineGun);
                activeWeaponType = Constants.SubMachineGun;
            }
        }
	}

    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        sniperRifle.SetActive(false);
        sawedOff.SetActive(false);
        subMachineGun.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;

    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
