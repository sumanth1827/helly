using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject obs;
    private float time =0f;
    private float rand;
    float[] nums = {0.75f, 1f, 1.25f, 1.5f, 1.75f, 2f};
    public float score = 0;
    private GameObject tmp;
    
    void Start()
    {
        rand = (nums[(int)Mathf.Round(Random.Range(0f, 5f))]) ;
        transform.position = new Vector3(transform.position.x, Random.Range(-2.7f, 7.8f), transform.position.z);
        tmp = GameObject.Find("Canvas");
        GetComponent<AudioSource>().volume = Mathf.Lerp(0, 1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
       if (score <= 10)
        {
            obs.GetComponent<obstacle>().speed = 14f;
            tmp.GetComponentInChildren<score>().n = 8;
        }
        else if(score>10)
        {
            obs.GetComponent<obstacle>().speed = 18f;
            tmp.GetComponentInChildren<score>().n = 12;

            if (score > 15)
            {
                obs.GetComponent<obstacle>().speed = 20f;
                tmp.GetComponentInChildren<score>().n = 15;
                if (score > 20)
                {
                    obs.GetComponent<obstacle>().speed = 25f;
                    tmp.GetComponentInChildren<score>().n = 25;
                    if (score > 25)
                    {
                        obs.GetComponent<obstacle>().speed = 30f;
                        tmp.GetComponentInChildren<score>().n = 32;

                    }

                }
              

            }
           

        }
        //transform.position = new Vector3(transform.position.x,Random.Range(-3.17f, 8.16f),transform.position.z);
        time += Time.deltaTime;
        if(time >= rand)
        {
            Instantiate(obs, transform.position, transform.rotation);
            transform.position = new Vector3(transform.position.x, Random.Range(-3f, 7.3f), transform.position.z);
            Invoke("generator",0);
            time = 0;
        }
        
    }
    void generator()
    {
        rand = (nums[(int)Mathf.Round(Random.Range(0f, 3f))]) ;
    }
    
}
