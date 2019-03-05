﻿using UnityEngine;

namespace GameJam.Interactables
{
    public class SpinInsideWashingMachine : MonoBehaviour
    {
        [SerializeField] private float zRotationsPerMinute = 1f;

        private void Update()
        {
            float zDegreesPerFrame = zRotationsPerMinute;
            transform.RotateAround(transform.position, transform.forward, zDegreesPerFrame);
        }
    }
}