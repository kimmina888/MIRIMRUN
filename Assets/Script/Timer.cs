using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    //font-size = 40;
    public static InputField InputName;
    public static float time;
    public Text TimePrint;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("school_hard") ||
            SceneManager.GetActiveScene().name.Equals("school_normal"))
        {
            time = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("school_hard")||
            SceneManager.GetActiveScene().name.Equals("school_normal"))
        {
            time += Time.deltaTime;
            TimePrint.text = ((int)(time)).ToString() + "√ !";
        }
        else
        {
            TimePrint.text = ((int)(time)).ToString() + "√ ";
        }
    }
}
