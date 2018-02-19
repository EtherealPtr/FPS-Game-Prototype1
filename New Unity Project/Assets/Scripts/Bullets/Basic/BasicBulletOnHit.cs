using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletOnHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision coll)
    {
        //print("hit");
        Destroy(gameObject);
    }
}
