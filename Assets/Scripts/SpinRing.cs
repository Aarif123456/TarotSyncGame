﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRing : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,-90* Time.deltaTime));
    }
}
