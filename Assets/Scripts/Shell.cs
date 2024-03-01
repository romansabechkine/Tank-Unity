using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime = 4;
    public float damage = 1;
    // Start is called before the first frame update

    //initialize explosion animation prefab and it's spawn point;
    public GameObject explosionPrefab;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            {
            Destroy(this.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(explosion, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion =  Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        if (collision.gameObject.tag == "Player")
            {
            collision.gameObject.GetComponent<Tank>().health -= damage;
            Destroy(this.gameObject);
            }
        if (collision.gameObject.tag == "Object")
            {
            Destroy(this.gameObject);
            }
        if (collision.gameObject.tag == "Wall")
            {
            Destroy(this.gameObject);
            }
        Destroy(explosion, 1.0f);
    }   
}
