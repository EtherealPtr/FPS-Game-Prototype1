using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float BulletLifeTime = 1.5f;

    [SerializeField]
    private float BulletSpeed = 50f;
    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, BulletLifeTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public float GetAmmoSpeed()
    {
        return BulletSpeed;
    }

    public float GetBulletLifeTime()
    {
        return BulletLifeTime;
    }
}
