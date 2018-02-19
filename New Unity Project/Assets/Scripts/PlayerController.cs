using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;

    [SerializeField]
    private float mouseSensitivity = 3.0f;

    PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
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
    }
}