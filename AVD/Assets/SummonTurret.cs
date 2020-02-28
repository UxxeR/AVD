using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonTurret : MonoBehaviour
{
    [SerializeField]
    private GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SpawnTurret")) {
            Instantiate(turret, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
