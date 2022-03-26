using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBall : MonoBehaviour
{
    
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.up * 10;
        _rigidbody.velocity = Vector3.right * 5;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        
    }

    private void OnTriggerEnter(Collider collider) {

        if(collider.tag == "Player"){
            
            //Debug.Log("Jo hat mich berührt");
            Destroy(gameObject);
            //Debug.Log("Jo hat mich berührt");
            
        }
        
    }
}
