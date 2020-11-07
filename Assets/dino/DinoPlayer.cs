using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPlayer : MonoBehaviour
{

    private bool jumpPressed = false;
    private int jumpHeight = 13;
    private float speed = 10;
    private Rigidbody rigidBody;
    private Vector3 origGravity;

    // Start is called before the first frame update
    private void Start()
    {
        origGravity = Physics.gravity;
        Physics.gravity = Physics.gravity * 2;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

    }

    private void FixedUpdate()
    {
        if (jumpPressed)
        {
            rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            jumpPressed = false;
        }

        rigidBody.velocity = new Vector3(Vector3.right.x * speed, rigidBody.velocity.y, 0);

    }

    private void OnTriggerEnter()
    {
        rigidBody.position = rigidBody.velocity = new Vector3(0, 3, 0);
        GetComponentInChildren<KillZoneGeneratorDino>().DeleteAllKillZones();
    }

    private void OnDestroy()
    {
        Physics.gravity = origGravity;
    }
}
