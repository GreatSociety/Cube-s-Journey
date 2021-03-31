using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTools : MonoBehaviour
{
    [SerializeField] Animator condition;

    private void Start()
    {
        condition.SetBool("Sett", false);
    }

    public void In()
    {
        condition.SetBool("Sett", true);
    }
    public void Out()
    {
        condition.SetBool("Sett", false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit(0);
    }

}
