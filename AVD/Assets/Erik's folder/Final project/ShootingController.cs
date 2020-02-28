using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player").transform.localScale.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(80000f * Time.deltaTime, 0));
        }
        else {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-80000f * Time.deltaTime, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 16)
        {
            Destroy(gameObject);
        } else if (col.gameObject.tag == "Enemy") {
            col.gameObject.SetActive(false);
        }
    }

}
