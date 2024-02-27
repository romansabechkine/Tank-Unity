using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{

    private Rigidbody rb;

    public float speed;

    public InputActionReference verticalMovement;
    // Start is called before the first frame update

    public InputActionReference rotationMovement;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = this.transform.position;
        movement += this.transform.forward * speed * verticalMovement.action.ReadValue<float>() * Time.deltaTime;
        rb.MovePosition(movement);

        Vector3 m_EulerAngleVelocity;
        Quaternion initialRotation = this.transform.rotation;
        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        m_EulerAngleVelocity = new Vector3(0, 2000, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationMovement.action.ReadValue<float>() * Time.deltaTime * m_EulerAngleVelocity);
        rb.MoveRotation( initialRotation * deltaRotation);
    }
}
