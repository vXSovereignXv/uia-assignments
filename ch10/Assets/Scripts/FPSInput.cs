using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float walkSpeed = 6.0f;
    public float runSpeed = 12.0f;
    public float strafeSpeed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveSpeed = Input.GetAxis("Fire3") > 0 ? runSpeed : walkSpeed;
        float deltaX = Input.GetAxis("Horizontal") * strafeSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, moveSpeed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
