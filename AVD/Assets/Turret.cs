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
    private bool isActive;
    private GameObject turret;
    [SerializeField]
    private Animator turretAnimator;

    public bool IsActive { get => isActive; set => isActive = value; }
    public Animator TurretAnimator { get => turretAnimator; set => turretAnimator = value; }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TurretSpawnAudio").GetComponent<AudioSource>().Play();
        turret = this.gameObject.transform.parent.parent.gameObject;
        turretAnimator = turret.GetComponent<Animator>();
        StartCoroutine(TurretDie(20f));
        BulletPositions[0].gameObject.GetComponent<ParticleSystem>().Stop();
        BulletPositions[1].gameObject.GetComponent<ParticleSystem>().Stop();
        BulletPositions[2].gameObject.GetComponent<ParticleSystem>().Stop();
        BulletPositions[3].gameObject.GetComponent<ParticleSystem>().Stop();
    }

    IEnumerator TurretDie(float time) {
        yield return new WaitForSeconds(time);
        turret.GetComponent<Animator>().SetTrigger("Die");
        yield return new WaitForSeconds(3f);
        Destroy(turret);
    }

    public IEnumerator Shoot(float cadence) {
        BulletPositions[i].gameObject.GetComponent<ParticleSystem>().Play();
        instantiatedPrefab = Instantiate(bullet, BulletPositions[i].position, BulletPositions[i].rotation);
        rb = instantiatedPrefab.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(cadence);
        BulletPositions[i].gameObject.GetComponent<ParticleSystem>().Stop();
        rb.AddForce(instantiatedPrefab.transform.forward * 20f, ForceMode.Impulse);
        i++;
        if (i >= BulletPositions.Length) i = 0;
        Destroy(instantiatedPrefab, 3f);
    }
}
