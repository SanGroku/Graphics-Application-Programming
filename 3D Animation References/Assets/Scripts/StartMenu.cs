using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //Load the bouncing ball scene
    public void LoadBouncingBall()
    {
        SceneManager.LoadScene("Bouncing Ball");
    }

    //Load the pendulum scene
    public void LoadPendulum()
    {
        SceneManager.LoadScene("Pendulum");
    }
}
