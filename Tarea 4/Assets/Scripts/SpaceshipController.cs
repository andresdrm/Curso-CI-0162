using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] float force = 5;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 5;
    // [SerializeField] float rotationSpeed = 180f;
    
    // float shipRadius = 0.5f;

    private Rigidbody2D movements;
    // Start is called before the first frame update
    void Start()
    {
        movements = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movements.velocity = new Vector2(horizontalInput * force, verticalInput * force);

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        if(movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation (Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    } 
}   
