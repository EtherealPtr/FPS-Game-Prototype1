using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;

    [SerializeField]
    private float mouseSensitivity = 3.0f;

    [SerializeField]
    private GameObject Gun;

    private PlayerShootScript PS_Script;

    private int AmmoType = 0;

        PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        PS_Script = Gun.GetComponent<PlayerShootScript>();
    }

    private void Update()
    {
        float m_xPos = Input.GetAxisRaw("Horizontal");
        float m_zPos = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * m_xPos;
        Vector3 moveVertical = transform.forward * m_zPos;

        // Calculate velocity
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * playerSpeed;
        motor.SetVelocity(velocity);

        // Calculate player rotation
        float m_yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0.0f, m_yRot, 0.0f) * mouseSensitivity;
        motor.SetRotation(rotation);

        // Calculate player camera rotation
        float m_xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRot = new Vector3(m_xRot, 0.0f, 0.0f) * mouseSensitivity;
        motor.SetCameraRotation(camRot);

        if (Input.GetButton("Fire1") && Time.time > PS_Script.GetNextFire())
        {
            PS_Script.PlayerShoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            AmmoType++;
            if (AmmoType > 1)
            {
                AmmoType = 0;
            }

            print(AmmoType);

            PS_Script.SetBulletType(AmmoType);
        }
    }
}