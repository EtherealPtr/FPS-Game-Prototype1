using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    //Public

    [SerializeField]
    private float FireRate = 0.25f;

    [SerializeField]
    private Transform GunEnd;

    [SerializeField]
    private Camera FpsCam;

    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private GameObject Grenade;

    //Private
    private WaitForSeconds ShotDuration = new WaitForSeconds(0.7f);

    private float NextFire;

    private float AmmoSpeed;

    private GameObject Ammo;

    private Rigidbody BulletInstance;

    // Use this for initialization
    void Start()
    {
        Ammo = Bullet;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerShoot()
    {
        NextFire = Time.time + FireRate;
        BulletInstance = Instantiate(Ammo.GetComponent<Rigidbody>(), GunEnd.position, GunEnd.rotation) as Rigidbody;
        AmmoSpeed = Ammo.GetComponent<BulletScript>().GetAmmoSpeed() * 100;
        StartCoroutine(ShotEffect());
    }

    public float GetNextFire()
    {
        return NextFire;
    }


    private IEnumerator ShotEffect()
    {
        BulletInstance.AddForce(GunEnd.forward * AmmoSpeed);
        yield return ShotDuration;

    }

    public void SetBulletType(int AmmoType)
    {
        switch(AmmoType)
        {
            case 0:
                {
                    Ammo = Bullet;
                    FireRate = 0.025f;
                    break;
                }
            case 1:
                {
                    Ammo = Grenade;
                    FireRate = 0.75f;
                    break;
                }
        }
  
    }

 }
