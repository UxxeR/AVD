using CreatorKitCode;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTriggerChest : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector pb;
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private GameObject itemModel;
    [SerializeField]
    private CharacterData character;
    [SerializeField]
    private Item item;
    [SerializeField]
    private TMP_Text money;
    private int currentMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            pb.Play();
            StartCoroutine(spawnItem());
        }
    }

    IEnumerator spawnItem()
    {
        yield return new WaitForSeconds(7.5f);
        GameObject currentItem = Instantiate(itemModel, hand.position, hand.rotation);
        currentItem.transform.parent = hand.transform;
        Destroy(currentItem, 2.5f);

        switch (itemModel.tag)
        {
            case "Money":
                currentMoney = Int32.Parse(money.text);
                currentMoney += 100;
                money.text = currentMoney.ToString();
                break;
            default:
                character.Inventory.AddItem(item);
                break;
        }
        
    }
}
