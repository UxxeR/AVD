using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private GameObject instantiatedPrefab;
    private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (instantiatedPrefab != null) Destroy(instantiatedPrefab);
                summonSphere();
        }
    }

    private void summonSphere()
    {
        instantiatedPrefab = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
        Destroy(instantiatedPrefab, 3f);
        rb = instantiatedPrefab.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, -10f), ForceMode.Impulse);
    }
}
