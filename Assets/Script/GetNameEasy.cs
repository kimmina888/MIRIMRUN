using PlayNANOO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetName : MonoBehaviour
{
    public InputField InputNameEasy;
    public float time;
    public string username;
    // Start is called before the first frame update
    Plugin plugin;

    void Awake(userClass user)
    {
        plugin = Plugin.GetInstance();

        plugin.RankingRecord("mirimrun123-RANK-4E6402CC-765DB9D7", (int)user.user_time, user.user_name, (state, message, rawData, dictionary) => {
            if (state.Equals(Configure.PN_API_STATE_SUCCESS))
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }
    string MakeID()
    {
        string id;
        id = "Mirim" + UnityEngine.Random.Range(0, 1000000);

        return id;
    }
    void Start(userClass user)
    {
        user.user_name = InputNameEasy.text;
        Awake(user);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
