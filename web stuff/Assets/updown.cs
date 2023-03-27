using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject tmp, spawn;
   
    void Start()
    {
        tmp = GameObject.Find("Canvas");
        spawn = GameObject.Find("obstacles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider ci)
    {
        if (ci.tag == "Player")
        {
            Time.timeScale = 0;
            tmp.GetComponentInChildren<score>().abc = false;
            tmp.GetComponentInChildren<Animator>().SetBool("end", true);
            ci.GetComponent<AudioSource>().enabled = false;
            GetComponent<AudioSource>().Play();
            spawn.GetComponent<AudioSource>().volume = Mathf.Lerp(spawn.GetComponent<AudioSource>().volume, 0f, 1f);

        }
    }

}
