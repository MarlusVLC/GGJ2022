using System;
using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Health playerHealth;
        [SerializeField] private Sprite fullHealthIcon;
        [SerializeField] private Sprite halfHealthIcon;
        [SerializeField] private Sprite emptyHealthIcon;
        [SerializeField] private Image[] healthUnitObject;

        private void Awake()
        {
            healthUnitObject = GetComponentsInChildren<Image>();
        }

        private void OnEnable()
        {
            playerHealth.HealthChanged += UpdateDisplay;
        }

        private void OnDisable()
        {
            playerHealth.HealthChanged -= UpdateDisplay;
        }

        private void UpdateDisplay(object sender, Health.HealthChangedEventArgs e)
        {
            int previousNumber = -1;

            for (int i = 0; i < e.MaxHealth; i++)
            {
                int floorHalf = Mathf.FloorToInt(i / 2);
                if (i < e.Health)
                {
                    healthUnitObject[floorHalf].gameObject.SetActive(true);
                    healthUnitObject[floorHalf].sprite = i % 2 == 0 ? halfHealthIcon : fullHealthIcon;
                    continue;
                }


                if (floorHalf == previousNumber)
                {
                    if (emptyHealthIcon)
                    {
                        healthUnitObject[floorHalf].sprite = emptyHealthIcon;
                    }
                    else
                    {
                        healthUnitObject[floorHalf].gameObject.SetActive(false);
                    }
                }
                previousNumber = floorHalf;

            }
        }
    }
}