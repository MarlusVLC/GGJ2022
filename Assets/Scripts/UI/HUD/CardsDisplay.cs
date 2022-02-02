using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Utilities;


namespace UI.HUD
{
    public class CardsDisplay : MonoBehaviour
    {
        [SerializeField] private Image selectedCard;
        [SerializeField] private CardInventory cardInventory;
        [SerializeField] private Image[] cardIcons;

        private Shadow _outline;
        private void Awake()
        {
            UpdateAvailability();
        }

        private void OnEnable()
        {
            cardInventory.OnCollectionModified += UpdateAvailability;
            cardInventory.OnChosenCardChanged += UpdateSelection;
        }

        private void OnDisable()
        {
            cardInventory.OnCollectionModified -= UpdateAvailability;
            cardInventory.OnChosenCardChanged -= UpdateSelection;
        }

        private void UpdateAvailability()
        {
            for (int i = 0; i < cardIcons.Length; i++)
            {
                if (cardInventory.CollectedCards.Count > i)
                {
                    cardIcons[i].sprite = cardInventory.CollectedCards[i].Icon;
                }
                else
                {
                    cardIcons[i].sprite = null;
                }
            }
        }

        private void UpdateSelection(int i)
        {
            foreach (Image icon in cardIcons)
            {
                _outline = icon.GetComponentInParent<Shadow>();
                _outline.enabled = false;
                selectedCard.sprite = null;
            }

            if (i != -1)
            {
                _outline = cardIcons[i].GetComponentInParent<Shadow>();
                _outline.enabled = true;
                selectedCard.sprite = cardIcons[i].sprite;
            }

        }
    } 
}