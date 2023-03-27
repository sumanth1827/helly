using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class obstacle : MonoBehaviour
{
    private Rigidbody rb;
    public float speed,z;
    public static bool die = false;
    public GameObject obj2,obj,tmp;
      private GameObject spawn;
   
       
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        z = Random.Range(0f, 1f);
        spawn = GameObject.Find("obstacles");
        tmp = GameObject.Find("Canvas");


    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, speed);
        if(die)
        {
            speed = 0;
            
        }
        if (CrossPlatformInputManager.GetButtonDown("r") && die)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            die = false;
            
        }
     
        /*if(z<0.5)
        {
            transform.localScale = new Vector3(transform.localScale.x, 5.844f, transform.localScale.z);
           
        }
        else if (z >= 0.5)
        {
            transform.localScale = new Vector3(transform.localScale.x, 3.1f, transform.localScale.z);
        }*/
    }
   
    private void OnTriggerEnter(Collider ci)
    {
      if(ci.tag == "Player")
        {
            
            ci.GetComponentInChildren<Animator>().enabled = false;
            ci.GetComponent<AudioSource>().enabled = false;
             ci.GetComponent<move>().enabled = false;
             ci.GetComponent<Rigidbody>().isKinematic = true;
            ci.transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 30f), 1f);
            GetComponent<AudioSource>().Play();
            Instantiate(obj, ci.transform.position, ci.transform.rotation);
            Instantiate(obj2, ci.transform.position, ci.transform.rotation);
            spawn.GetComponent<AudioSource>().volume = Mathf.Lerp(spawn.GetComponent<AudioSource>().volume, 0f, 1f);
            tmp.GetComponentInChildren<score>().abc = false;
            tmp.GetComponentInChildren<Animator>().SetBool("end", true);
            die = true;
            

        }
      if(ci.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

}
