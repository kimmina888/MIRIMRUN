using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour
{

    public InputField curInputName;
    public static InputField InputName;
    public Text TimePrint;
    public static float clearTime;

    // Start is called before the first frame update
    void Start()
    {
        TimePrint.text = ((int)clearTime).ToString()+"��";
    }
    private void Update()
    {
        InputName = curInputName;
    }
}
