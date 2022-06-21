using PlayNANOO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNameHard : MonoBehaviour
{
    Plugin plugin;

    void Awake()
    {
        plugin = Plugin.GetInstance();

        plugin.RankingRecord("mirimrun123-RANK-D76F2474-FC33C14A", (int)Timer.time, Ranking.InputName.text, (state, message, rawData, dictionary) =>
        {
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
    void Start()
    {
        MakeID();
        Awake();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
