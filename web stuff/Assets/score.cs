using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public float score1;
    //public Text text1;
    private TMP_Text text1;
    public bool abc = true;
    public int n;
    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        text1 = GetComponent<TMP_Text>();
        abc = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (abc)
        {
            score1 += n* Time.deltaTime;
          

            text1.text = score1.ToString("0") + " meters";
        }
    }
}
