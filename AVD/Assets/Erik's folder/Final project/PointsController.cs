using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField]
    private GameObject textGameObject;
    private TMP_Text text;
    private int points;

    public int Points { get => points; set => points = value; }

    // Start is called before the first frame update
    void Start()
    {
        text = textGameObject.GetComponent<TMP_Text>();
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = points.ToString();
    }
}
