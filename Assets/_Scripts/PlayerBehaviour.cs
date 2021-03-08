// this script should be attached to the player character
// this script controls movement and jumping
// it does not control animations for character model -> that script is contained in the asset prefabs and has had its movement code removed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement Input Options")]
    public MovementOptionSO curreMovementOptions;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public CharacterController controller;

    [Header("Movement")]
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;
    public Vector3 velocity;

    [Header("Ground")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Animations")]
    public Animator anim;

    [Header("Items")]
    public static bool hasSuperJump;
    public float superJumpMultiplier = 3.0f;
    public static bool hasSuperSpeed;
    public static float superSpeedMultiplier = 2.0f;
    public static int superSpeedDuration = 3000;
    public static float currSpeedMultiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        //loadCurrentMovementOptions();
    }

    // Update is called once per frame - once every 16.6666ms

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y > 0)
        {
            velocity.y = -2.0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        Vector3 move = transform.right * x * currSpeedMultiplier + transform.forward * z * currSpeedMultiplier;

        controller.Move(move * maxSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            if (hasSuperJump)
            {
                Debug.Log("Super Jumping");
                velocity.y = Mathf.Sqrt(jumpHeight * superJumpMultiplier * -2.0f * gravity);
                hasSuperJump = false;
            }
            else
            {
                Debug.Log("Jumping");
                velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void loadCurrentMovementOptions()
    {

        upKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), curreMovementOptions.upKey.name);
        downKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), curreMovementOptions.downKey.name);
        rightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), curreMovementOptions.rightKey.name);
        leftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), curreMovementOptions.leftkey.name);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
