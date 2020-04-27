using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private Animator creditsText;

    private void Update()
    {
        if (Input.anyKey) {
            credits.SetActive(false);
        }
    }

    public void StartCredits() {
        credits.SetActive(true);
        creditsText.Play("credits");
    }
}
