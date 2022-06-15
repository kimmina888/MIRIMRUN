using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void replay()
    {
        SceneManager.LoadScene("AttackTest");
    }

    public void Ranking()
    {
        SceneManager.LoadScene("Ranking");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameList");
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoSchool()
    {
        SceneManager.LoadScene("school");
    }

    public void Gotown1()
    {
        SceneManager.LoadScene("Main");
    }

    public void Gotown2()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoGameList()
    {
        SceneManager.LoadScene("GameList");
    }

    public void SelectAvatar()
    {
        SceneManager.LoadScene("SelectAvatar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
