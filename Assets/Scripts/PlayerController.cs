using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    public static Vector3 DropPosition
        => player.transform.position + Vector3.forward*3;

    static PlayerController player; // не синглтон, но подразумевается что игрок один единственный

    // Start is called before the first frame update
    void Start()
    {
        player = this;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime 
            * speed * forwardInput);

        transform.Rotate(Vector3.up, Time.deltaTime
            * turnSpeed * horizontalInput);

    }
}
