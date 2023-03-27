using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class move : MonoBehaviour
{

    private Rigidbody rb;
    private AudioSource a;
    private bool esc = false;
    public float fall = 10f;
    private GameObject tmp;
    private bool muted;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        esc = false;
        muted = false;
        tmp = GameObject.Find("Canvas");
        a = GetComponent<AudioSource>();
        Application.targetFrameRate = 300;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);
        rb.AddForce(0, -fall * Time.deltaTime, 0);
        if (CrossPlatformInputManager.GetButton("w"))
        {
            rb.velocity = new Vector3(0, 15f, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(15, 0, 0), 0.2f);
            a.pitch = Mathf.Lerp(a.pitch, 1.3f, 0.1f);

        }
        if (CrossPlatformInputManager.GetButton("s"))
        {
            rb.velocity = new Vector3(0, -15f, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(-15, 0, 0), 0.2f);
            a.pitch = Mathf.Lerp(a.pitch, 0.7f, 0.1f);
        }
        if (!CrossPlatformInputManager.GetButton("w") || !CrossPlatformInputManager.GetButton("w"))
        {

            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), 0.2f);

        }
        if (CrossPlatformInputManager.GetButton("a"))
        {
            rb.velocity = new Vector3(0, 0, 15f);
            a.pitch = Mathf.Lerp(a.pitch, 0.7f, 0.1f);
            // transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(15, 0, 0), 0.2f);

        }
        if (CrossPlatformInputManager.GetButton("d"))
        {
            rb.velocity = new Vector3(0, 0, -15f);
            a.pitch = Mathf.Lerp(a.pitch, 1.3f, 0.1f);
            // transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(15, 0, 0), 0.2f);

        }
        if (CrossPlatformInputManager.GetButton("w") && CrossPlatformInputManager.GetButton("d"))
        {
            rb.velocity = new Vector3(0, 10.6f, -10.6f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(15, 0, 0), 0.2f);
            a.pitch = Mathf.Lerp(a.pitch, 1.3f, 0.1f);

        }
        if (CrossPlatformInputManager.GetButton("w") && CrossPlatformInputManager.GetButton("a"))
        {
            rb.velocity = new Vector3(0, 10.6f, 10.6f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(15, 0, 0), 0.2f);
            a.pitch = Mathf.Lerp(a.pitch, 0.7f, 0.1f);

        }

        if (CrossPlatformInputManager.GetButton("s") && CrossPlatformInputManager.GetButton("a"))
        {
            rb.velocity = new Vector3(0, -10.6f, 10.6f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(-15, 0, 0), 0.2f);
            a.pitch = Mathf.Lerp(a.pitch, 0.7f, 0.1f);

        }
        if (CrossPlatformInputManager.GetButton("s") && CrossPlatformInputManager.GetButton("d"))
        {
            rb.velocity = new Vector3(0, -10.6f, -10.6f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(-15, 0, 0), 0.2f);
            a.pitch = Mathf.Lerp(a.pitch, 1.3f, 0.1f);

        }
        if (!CrossPlatformInputManager.GetButton("w") && !CrossPlatformInputManager.GetButton("a") && !CrossPlatformInputManager.GetButton("s") && !CrossPlatformInputManager.GetButton("d"))
        {
            a.pitch = Mathf.Lerp(a.pitch, 1f, 0.1f);
        }
        if (CrossPlatformInputManager.GetButtonDown("escape") && !esc)
        {
            Time.timeScale = 0;
            tmp.GetComponent<Animator>().SetBool("pause", true);
            Cursor.visible = true;
            esc = true;




        }
        else if (CrossPlatformInputManager.GetButtonDown("escape") && esc)
        {
            Time.timeScale = 1;
            tmp.GetComponent<Animator>().SetBool("pause", false);
            Cursor.visible = false;
            esc = false;
        }
        if (Time.timeScale == 0)
        {
            if (CrossPlatformInputManager.GetButtonDown("r"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
        if (esc)
        {

            if (CrossPlatformInputManager.GetButtonDown("q"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            if (CrossPlatformInputManager.GetButtonDown("m") && !muted)
            {
                AudioListener.volume = 0f;

                muted = true;
            }
            else if (CrossPlatformInputManager.GetButtonDown("m") && muted)
            {
                AudioListener.volume = 1f;
                muted = false;

            }
        }
    }

}
