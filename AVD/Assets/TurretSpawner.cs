using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private GameObject instantiatedPrefab;

    private void summonTurret()
    {
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") {
            if (GameObject.Find("Turret(Clone)") != null) Destroy(GameObject.Find("Turret(Clone)"));
            summonTurret();
        }
        Destroy(gameObject);
    }
}
