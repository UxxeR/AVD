using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(GameObject.Find("Character").transform.position.x, GameObject.Find("Character").transform.position.y, 0f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
