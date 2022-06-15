using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //font-size = 40;
    public static float time;
    public Text TimePrint;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimePrint.text = ((int)(time)).ToString();
    }
}
