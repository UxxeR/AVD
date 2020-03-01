using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReward : MonoBehaviour
{

    [SerializeField]
    private int pointsGranted;
    private PointsController pointsController;
    private AudioSource sound;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        pointsController = GameObject.Find("Player").GetComponent<PointsController>();
        sound = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(Collect());
        }
    }

    private IEnumerator Collect() {
        sound.Play();
        animator.SetBool("collected", true);
        yield return new WaitForSeconds(0.15f);
        gameObject.SetActive(false);
        pointsController.Points += pointsGranted;
    }

}
