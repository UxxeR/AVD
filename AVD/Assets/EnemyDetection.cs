using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject cannon;
    private Turret turret;
    private bool enemyDetected;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.Find("Turret(Clone)").GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.position -= cannon.transform.position;
        Quaternion qua = Quaternion.LookRotation(enemy.transform.position, Vector3.up);
        cannon.transform.rotation = Quaternion.RotateTowards(cannon.transform.rotation, qua, 10f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyDetected) {
            turret.Active = true;
        }
        else {
            turret.Active = false;
        }
    }
}
