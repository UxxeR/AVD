using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    private PlayableDirector pb;
    // Start is called before the first frame update
    void Start()
    {
       pb = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        pb.Play();
    }
}
