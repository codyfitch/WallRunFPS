using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WallRun : MonoBehaviour {

    private bool isWallR = false;
    private bool isWallL = false;
    private RaycastHit hitR;
    private RaycastHit hitL;
    private int jumpCount = 0;
    private RigidbodyFirstPersonController cc;
    private Rigidbody rb;

	
	void Start () {
        cc = GetComponent<RigidbodyFirstPersonController>();
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
	    if(cc.Grounded)
        {
            jumpCount = 0;
        }

            if (Physics.Raycast(transform.position, transform.right, out hitR, 1))
            {
                if (hitR.transform.tag == "Wall")
                {
                    isWallR = true;
                    isWallL = false;
                    jumpCount += 1;
                    rb.useGravity = false;
                    StartCoroutine(afterRun());
                }
            }
       
            if (Physics.Raycast(transform.position, -transform.right, out hitL, 1))
            {
                if (hitL.transform.tag == "Wall")
                {
                    isWallL = true;
                    isWallR = false;
                    jumpCount += 1;
                    rb.useGravity = false;
                    StartCoroutine(afterRun());
                }
            }
	}

    IEnumerator afterRun ()
    {
        yield return new WaitForSeconds(1.0f);
        isWallL = false;
        isWallR = false;
        rb.useGravity = true;
    }
}
