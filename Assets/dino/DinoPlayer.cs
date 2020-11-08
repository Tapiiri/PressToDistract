using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoPlayer : MonoBehaviour
{

    private bool jumpPressed = false;
    [SerializeField] private int jumpHeight = 40;
    private float speed = 10;
    private float bufferTimer = 0f;
    private Rigidbody rigidBody;
    private Vector3 origGravity;
    private bool noJumping = false;
    public float acceleration;

    // Start is called before the first frame update
    private void Start()
    {
        origGravity = Physics.gravity;
        Physics.gravity = Physics.gravity * 2;
        FindObjectOfType<AudioManager>().Play("New Game");
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyUp(KeyCode.Space) && noJumping))
        {
            jumpPressed = true;
            bufferTimer = 0f;
        }

        if (jumpPressed)
        {

            bufferTimer += Time.deltaTime;
            if (bufferTimer > 0.3f)
            {
                jumpPressed = false;
                bufferTimer = 0f;
            }

        }

    }

    private void OnCollisionEnter()
    {
        noJumping = false;
        FindObjectOfType<AudioManager>().Play("Hit Ground");
    }

    private void FixedUpdate()
    {
        if (jumpPressed)
        {
            if (!noJumping)
            {
                rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
                noJumping = true;
                jumpPressed = false;
                FindObjectOfType<AudioManager>().Play("Hit Ground");
            }
        }
        speed += acceleration;
        rigidBody.velocity = new Vector3(Vector3.right.x * speed, rigidBody.velocity.y, 0);

    }

    void OnTriggerEnter()
    {
        rigidBody.position = rigidBody.velocity = new Vector3(0, 3, 0);
        FindObjectOfType<AudioManager>().Play("Game Over");
        GetComponentInChildren<KillZoneGeneratorDino>().DeleteAllKillZones();
        SceneManager.LoadScene(1);
    }

    private void OnDestroy()
    {
        Physics.gravity = origGravity;
    }
}
