using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        [SerializeField] private RectTransform[] cards;
        [Header("SelectionPosition")]
        [SerializeField] private RectTransform backPos;
        [SerializeField] private RectTransform midPos;
        [SerializeField] private RectTransform frontPos;
        
        private Shadow _outline;
        private Sequence rotationSequence = DOTween.Sequence();
        private void Awake()
        {
            // UpdateAvailability();
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
            for (int i = 0; i < cards.Length; i++)
            {
                if (cardInventory.CollectedCards.Count > i)
                {
                    cards[i].GetComponentInChildren<Image>().sprite = cardInventory.CollectedCards[i].Icon;
                }
                else
                {
                    cards[i].GetComponentInChildren<Image>().sprite = null;
                }
            }
        }

        private void UpdateSelection(int i)
        {
            // foreach (Image icon in cardIcons)
            // {
            //     _outline = icon.GetComponentInParent<Shadow>();
            //     _outline.enabled = false;
            //     selectedCard.sprite = null;
            // }
            //
            // if (i != -1)
            // {
            //     _outline = cardIcons[i].GetComponentInParent<Shadow>();
            //     _outline.enabled = true;
            //     selectedCard.sprite = cardIcons[i].sprite;
            // }

            cards.Rotate();
            
            //LAST = FRONT
            //FIRST = BACK
            Vector2 newAnchoredPos;
            for (int j = 0; j < cards.Length; j++)
            {
                cards[j].SetSiblingIndex(j);

                if (j == 0)
                {
                    newAnchoredPos = new Vector2(cards[j].anchoredPosition.x + (25 * cards.Length),
                                                        cards[j].anchoredPosition.y + (25 * cards.Length));
                    rotationSequence.Append(cards[j].DOAnchorPos(newAnchoredPos,0.5f));
                    continue;
                }
                
                newAnchoredPos = new Vector2(cards[j].anchoredPosition.x - 25,
                    cards[j].anchoredPosition.y - 25);
                rotationSequence.Append(cards[j].DOAnchorPos(newAnchoredPos, 0.5f));
            }

            rotationSequence.Play();

        }
    } 
}