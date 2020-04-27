using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector pb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            pb.Play();
            this.gameObject.GetComponent<TimelineTrigger>().enabled = false;
        }
    }
}
