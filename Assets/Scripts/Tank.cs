using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{

    private Rigidbody rb;

    public float speed =10;
    public InputActionReference verticalMovement;
    public InputActionReference rotationMovement;

    public InputActionReference fireAction;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public float  fireRate = 1f;
    public float nextFire = 0f;
    public float health = 2;
    // Start is called before the first frame update

    // Big explosion if the tank is destroyed;
    public GameObject explosionPrefab2;

    // spawn point for smoke
    public GameObject smokeSpawnPoint;

    // smoke prefab
    public GameObject smokePrefab;

    public GameObject flameSpawnPoint;
    public GameObject flamePrefab;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    Vector3 m_EulerAngleVelocity;
    void Update()
    {
        Vector3 movement = this.transform.position;
        movement += this.transform.forward * speed * verticalMovement.action.ReadValue<float>() * Time.deltaTime;
        rb.MovePosition(movement);

        Quaternion initialRotation = this.transform.rotation;
        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        m_EulerAngleVelocity = new Vector3(0, 1000, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationMovement.action.ReadValue<float>() * Time.deltaTime * m_EulerAngleVelocity);
        rb.MoveRotation( initialRotation * deltaRotation);
       if (fireAction.action.triggered && Time.time > nextFire)
        {
            nextFire = Time.time +0.2f / fireRate;
            Shoot();
        }
        if (health <= 0)
        {
            GameObject explosion2 =  Instantiate(explosionPrefab2, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            Destroy(explosion2, .5f);
        }
        Smoke();
        
        }
    GameObject flame;
    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, this.transform.rotation);
        flame = Instantiate(flamePrefab, flameSpawnPoint.transform.position, this.transform.rotation);
        Destroy(flame, 1f);
    }

    GameObject smoke;
    void Smoke()
    {
        //GameObject smoke = GameObject.Find("SmokeEffect(Clone)");
        //smoke_rotation = this.transform.rotation;
        if ((verticalMovement.action.IsInProgress() || rotationMovement.action.IsInProgress()) && smoke == null)
        {
            smoke = Instantiate(smokePrefab, smokeSpawnPoint.transform.position, smokeSpawnPoint.transform.rotation);
        }
        else if (smoke) {
            Destroy(smoke);
        }
    }
}
