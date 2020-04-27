using CreatorKitCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy = null;
    [SerializeField]
    private Turret turret;
    private Vector3 lastPosition = Vector3.zero;
    private Quaternion lookAtRotation;
    private bool canAttack;
    private float speed = 100f;
    private float angle = 5f;

    private void Start()
    {
        StartCoroutine(CanAttack());
    }
    void Update()
    {
        if(enemy == null) turret.TurretAnimator.SetTrigger("Idle");
        if (turret.IsActive)
        {
            if (lastPosition != enemy.transform.position)
            {
                lastPosition = enemy.transform.position;
                lookAtRotation = Quaternion.LookRotation(lastPosition - transform.position);
            }

            if (transform.rotation != lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
            }

            if (transform.rotation.y >= lookAtRotation.y - angle && transform.rotation.y <= lookAtRotation.y + angle)
            {
                turret.StartCoroutine(turret.Shoot(0.5f));
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && other.name != "Training Dummy" && canAttack == true)
        {
            turret.TurretAnimator.SetTrigger("Attacking");
            turret.IsActive = true;
            enemy = other.gameObject;
            if (enemy.GetComponent<CharacterData>().Stats.CurrentHealth == 0) {
                enemy = null;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" && other.name != "Training Dummy")
        {
            enemy = null;
            turret.IsActive = false;
        }
    }

    IEnumerator CanAttack() {
        yield return new WaitForSeconds(2.75f);
        canAttack = true;
    }
}
