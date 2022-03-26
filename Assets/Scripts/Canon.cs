using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{


    //public GameObject text;
    public GameObject procetilePrefab;
    public GameObject canvas;
    public Text hitText;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        //text.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed primary button.");
            GameObject projectile = Instantiate(procetilePrefab) as GameObject;
            projectile.transform.position = this.transform.GetChild(0).gameObject.transform.position;
        }

        if(count == 5){
            this.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);
            //text.SetActive(false);
            count = 0;
            hitText.text = "HITS: 5";
        }

            

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag =="Ball"){
            count++;
            Debug.Log("Treffer");;
            hitText.text = "HITS: " + (5 - count);
        }

        if(other.tag == "Item"){
            count = 0;
            hitText.text = "HITS: 5";
        }
    }
}
