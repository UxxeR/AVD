using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReward : MonoBehaviour
{

    [SerializeField]
    private int pointsGranted;
    private PointsController pointsController;

    // Start is called before the first frame update
    void Start()
    {
       pointsController = GameObject.Find("Player").GetComponent<PointsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            pointsController.Points += pointsGranted;
            gameObject.SetActive(false);
        }
    }

}
