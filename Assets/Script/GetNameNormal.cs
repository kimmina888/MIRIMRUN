using PlayNANOO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNameNormal : MonoBehaviour
{
    public float time;
    public string username;
    // Start is called before the first frame update
    Plugin plugin;

    void Awake()
    {
        plugin = Plugin.GetInstance();

        plugin.RankingRecord("mirimrun123-RANK-4E6402CC-765DB9D7", (int)Timer.time, Ranking.InputName.text, (state, message, rawData, dictionary) => {
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
        MakeID();
        Awake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
