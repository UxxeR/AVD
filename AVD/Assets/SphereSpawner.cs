using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private GameObject instantiatedPrefab;
    private Rigidbody rb;
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private Animator characterAnimator;
    [SerializeField]
    private GameObject weapon;
    private int cooldown = 3;
    private bool onCooldown = false;
    [SerializeField]
    private TMP_Text cooldownText;
    [SerializeField]
    private GameObject cooldownGameObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ThrowTurret());
        }
    }

    private void summonSphere()
    {
        instantiatedPrefab = Instantiate(prefab, gameObject.transform.position, character.transform.rotation);
        Destroy(instantiatedPrefab, 3f);
        rb = instantiatedPrefab.GetComponent<Rigidbody>();
        rb.AddForce(character.transform.forward * 5f, ForceMode.Impulse);
    }

    IEnumerator ThrowTurret() {
        if (!onCooldown)
        {
            cooldownText.text = cooldown.ToString();
            onCooldown = true;
            weapon.SetActive(false);
            characterAnimator.SetTrigger("Throw");
            yield return new WaitForSeconds(0.5f);
            if (instantiatedPrefab != null) Destroy(instantiatedPrefab);
            summonSphere();
            yield return new WaitForSeconds(0.5f);
            cooldownGameObject.SetActive(true);
            characterAnimator.SetTrigger("Respawn");
            weapon.SetActive(true);
            for (int i = cooldown; i > 0; i--)
            {
                cooldownText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }
            onCooldown = false;
            cooldownGameObject.SetActive(false);
        }
    }
}
