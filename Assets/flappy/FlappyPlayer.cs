using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlayer : MonoBehaviour
{

    private bool jumpPressed = false;
    public int jumpHeight = 7;
    private float speed = 10;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("New Game");
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
            FindObjectOfType<AudioManager>().Play("Flap");
            jumpPressed = false;
        }

        rigidBody.velocity = new Vector3(Vector3.right.x * speed, rigidBody.velocity.y, 0);

    }

    private void OnTriggerEnter()
    {
        rigidBody.position = rigidBody.velocity = new Vector3(0, 3, 0);
        GetComponentInChildren<KillZoneGeneratorFlappy>().DeleteAllKillZones();
        FindObjectOfType<AudioManager>().Play("Game Over");
        SceneManager.LoadScene(2);
    }
}
