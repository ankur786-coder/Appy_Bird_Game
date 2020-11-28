using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
