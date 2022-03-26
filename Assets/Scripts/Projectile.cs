using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
     public float _speed = 30f;
    Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Launch();
    }

    void Launch()
    {
         _rigidbody.velocity = Vector3.up * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
       
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter(Collider other) {
       
        Destroy(gameObject);
       
    }
}
