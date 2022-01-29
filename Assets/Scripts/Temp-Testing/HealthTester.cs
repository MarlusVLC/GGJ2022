using System;
using Entities;
using UnityEngine;

namespace Temp_Testing
{
    public class HealthTester : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                _health.RecoverHealth(1);
            }

            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                _health.TakeDamage(1);
            }
        }
    }
}