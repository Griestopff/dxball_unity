using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ballItemPrefab;
    Rigidbody _rigidbody;


    enum State {}
    State state;
    // Start is called before the first frame update
    void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.MovePosition(new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 50)).x, -17, 0));

        //switch (GameManager._state)
        //{
         //    case State.INIT:
          //      this.transform.GetChild(0).gameObject.SetActive(false);    
        //}

       
    }

    private void OnTriggerEnter(Collider collider) {

        if(collider.tag == "Item"){
        
            //Debug.Log("Aufgesammelt");
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(true);  
              
            
        }
        if(collider.tag == "ItemBall"){
        
            Debug.Log("Aufgesammelt");
            Instantiate(ballItemPrefab);
               
            
        }
   
    
    }
}
