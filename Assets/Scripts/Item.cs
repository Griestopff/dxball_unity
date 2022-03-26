using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
       // _rigidbody.transform = itembrick.transform
        _rigidbody.velocity = Vector3.up * 10;
        _rigidbody.velocity = Vector3.left * 5;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        
    }

    private void OnTriggerEnter(Collider collider) {

        if(collider.tag == "Player"){
            Destroy(gameObject);
            //Debug.Log("Jo hat mich berührt");
            
        }
        
    }
}
