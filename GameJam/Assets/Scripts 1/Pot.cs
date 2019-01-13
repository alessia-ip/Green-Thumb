using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public float jumpSpeed = 4;
    public float movementSpeed = 2;
    public float groundingDistance = 1f;
    float smooth = 7.0f;
    float tiltAngle = -30.0f;

    private float horizontalDirection = 0;
    private float verticalDirection = 0;
    private float tiltAroundZ;
    private float tiltAroundX;

    private bool isGrounded;

    private Rigidbody potBody;




    // Start is called before the first frame update
    void Start()
    {
        potBody = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * -tiltAngle;
        horizontalDirection = Input.GetAxis("Horizontal");
        verticalDirection   = Input.GetAxis("Vertical");

        if (Mathf.Abs(tiltAroundX) > Mathf.Abs(tiltAroundZ)) tiltAroundZ = 0f;
        else tiltAroundX = 0f;

        if (Mathf.Abs(horizontalDirection) > Mathf.Abs(verticalDirection)) verticalDirection = 0f;
        else horizontalDirection = 0f;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundingDistance); 

        if (isGrounded && Input.GetAxis("Jump") > 0.01) {
            potBody.velocity = (Vector3.up*jumpSpeed);
        }



        if (transform.rotation.z <= 20)
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * smooth);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 20), Time.fixedDeltaTime * smooth);
    
        if (transform.rotation.x <= 20)
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * smooth);
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(20, 0, 0), Time.fixedDeltaTime * smooth);



        if (isGrounded) {
            potBody.velocity = new Vector3(0, potBody.velocity.y, 0);
        }
        else {
            potBody.velocity = new Vector3(horizontalDirection * movementSpeed, potBody.velocity.y, verticalDirection* movementSpeed);
        }

    }
}
