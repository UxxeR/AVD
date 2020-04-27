using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneAutomatic : MonoBehaviour
{
    [SerializeField]
    private int level;

    private void Start()
    {
        NextLevel();   
    }

    public void NextLevel() {
        SceneManager.LoadScene(this.level);
    }
}
