using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBackground : MonoBehaviour
{
    private Vector3 startPositon;
    private float repeatWidth;
    void Start()
    {
        startPositon = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < startPositon.x - repeatWidth)
        {
            transform.position = startPositon;
        }
    }
}
