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

    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = this.transform.position;
        movement = Vector3.forward * speed * verticalMovement.action.ReadValue<float>() * Time.deltaTime;
        rb.MovePosition(movement);
    }
}
