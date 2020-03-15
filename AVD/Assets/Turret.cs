using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private GameObject instantiatedPrefab;
    private Rigidbody rb;
    [SerializeField]
    private Transform[] BulletPositions;
    private int i;
    [SerializeField]
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TurretSpawnAudio").GetComponent<AudioSource>().Play();
        Destroy(GameObject.Find("Turret(Clone)"), 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            instantiatedPrefab = Instantiate(bullet, BulletPositions[i].position, BulletPositions[i].rotation);
            i++;
            if (i >= BulletPositions.Length) i = 0;
            Destroy(instantiatedPrefab, 3f);
            rb = instantiatedPrefab.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 0, 25f), ForceMode.Impulse);
        }
    }
}
