using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float _speed = 30f;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    Renderer _renderer;
    int _collisioncount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
       Invoke("Launch", 0.5f);
    }

    void Launch()
    {
         _rigidbody.velocity = Vector3.up * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;

        if(!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }

        if(_collisioncount == 10){
            _rigidbody.velocity = Vector3.up * _speed;
            
            _collisioncount = 0;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);

        
        
    } 
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall"){
            _collisioncount++;
            Debug.Log(_collisioncount);
        }
        if(other.tag == "Player")
        {
             _collisioncount = 0;
              Debug.Log(_collisioncount);
        }
    }
}
