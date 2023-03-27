using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class loader : MonoBehaviour
{
    // Start is called before the first frame update
    private bool muted;
    void Start()
    {
        Cursor.visible = false;
        muted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("r"))
        {
            Debug.Log("happen");
            GetComponent<Animator>().SetBool("start", true);
        }
        if (Input.GetKeyDown("m") && !muted)
        {
            AudioListener.volume = 0f;

            muted = true;
        }
        else if (Input.GetKeyDown("m") && muted)
        {
            AudioListener.volume = 1f;
            muted = false;

        }
        if (Input.GetKey("q"))
        {
            Application.Quit();
        }
    }
    public void laod()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
