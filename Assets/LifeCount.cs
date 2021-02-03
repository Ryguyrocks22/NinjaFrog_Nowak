using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;

    public void LoseLife()
    {
        livesRemaining--;

        lives[livesRemaining].enabled = false;

        if(livesRemaining == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            LoseLife();
    }

}
