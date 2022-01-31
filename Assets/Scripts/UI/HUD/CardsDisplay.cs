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

        private Outline _outline;
        private void Awake()
        {
            UpdateAvailability();
        }

        private void OnEnable()
        {
            cardInventory.OnCardCollected += UpdateAvailability;
            cardInventory.OnChooseCard += UpdateSelection;
        }

        private void OnDisable()
        {
            cardInventory.OnCardCollected -= UpdateAvailability;
            cardInventory.OnChooseCard -= UpdateSelection;
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
            if (i == -1) return;
            foreach (Image icon in cardIcons)
            {
                _outline = icon.GetComponentInParent<Outline>();
                _outline.enabled = false;
            }
            _outline = cardIcons[i].GetComponentInParent<Outline>();
            _outline.enabled = true;
            selectedCard.sprite = cardIcons[i].sprite;
        }
    } 
}