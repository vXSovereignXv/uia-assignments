using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;
    public float maxCameraAngleX = 15f;
    private float _rotY;
    private float _rotX;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;
        _offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0)
        {
            _rotY += horInput * rotSpeed;
        }
        else
        {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }

        _rotX += Input.GetAxis("Mouse Y") * rotSpeed * -1;
        _rotX = Mathf.Clamp(_rotX, -1 * maxCameraAngleX, maxCameraAngleX);

        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}
