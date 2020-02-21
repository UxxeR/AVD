using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    // Update is called once per frame
    public void LoadSceneLevel(int level)
    {
            SceneManager.LoadSceneAsync(level);
    }
}
