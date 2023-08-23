using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody thisRB;

    public float jumpPower = 10;

    public float jumpInterval = 0.5f;

    private float jumpCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0;

        if (canJump)
        {
            bool JumpInput = Input.GetKeyDown(KeyCode.Space);
            if (JumpInput)
            {
                Jump();
            }
        }

    }

    private void Jump()
    {
        jumpCooldown = jumpInterval;
        thisRB.velocity = Vector3.zero;
        thisRB.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }
}
