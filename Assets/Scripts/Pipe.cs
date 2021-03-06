﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float minPositionY;
    [SerializeField] float maxPositionY;

    void Start()
    {
        ChangePosition();
    }

    public void ChangePosition()
    {
        float positionY = Random.Range(minPositionY, maxPositionY);
        transform.localPosition = new Vector3(transform.localPosition.x, positionY, transform.localPosition.z);
    }
}
