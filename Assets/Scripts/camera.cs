using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class camera : MonoBehaviour

{
    public GameObject tank; //joueur 
    private Vector3 suivre;
    
    // Start is called before the first frame update
    void Start()
    {
            suivre = transform.position - tank.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tank.transform.position + suivre;
    }
}
