using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    private Animator animator;
    [SerializeField]
    private float force = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("eagle").GetComponent<Animator>();
        gameObject.GetComponent<AudioSource>().Play();
        if (GameObject.Find("Player").transform.localScale.x > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        else {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 16) //Terrain
        {
            Destroy(gameObject);
        } else if (col.gameObject.tag == "Enemy") {
            StartCoroutine(DestroyEnemy(col));
        }
    }


    private IEnumerator DestroyEnemy(Collider2D col)
    {
        col.gameObject.GetComponent<AudioSource>().Play();
        animator.SetBool("death", true);
        yield return new WaitForSeconds(0.1f);
        col.gameObject.SetActive(false);
    }
}
