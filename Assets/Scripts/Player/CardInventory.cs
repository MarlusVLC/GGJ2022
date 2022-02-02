using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;
using Utilities;

namespace Player
{
    public class CardInventory : MonoCache
    {
        [SerializeField] private List<Card> collectedCards;
        [Header("Player attributes")]
        [SerializeField] private Health playerHealth;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAttack playerAttack;
        [Header("Input")] 
        [SerializeField] private KeyCode cardUseInput;
        

        private int _currentCardIndex = -1;

        private void Update()
        {
            SelectCards();
            UseCard();
        }

        public event Action OnCollectionModified;
        public event Action<int> OnChosenCardChanged;
        
        public List<Card> CollectedCards => collectedCards;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Card card) && collectedCards.Count < 5)
            {
                collectedCards.Add(card);
                OnCollectionModified?.Invoke();
                if (collectedCards.Count == 1) CurrentCardIndex = 0;
                Destroy(other.gameObject);
            }
        }

        private void SelectCards()
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                // Debug.Log(collectedCards.Count);
                if (collectedCards.Count == 0) return;
                _currentCardIndex += Convert.ToInt32(Input.GetKeyDown(KeyCode.Q));
                _currentCardIndex -= Convert.ToInt32(Input.GetKeyDown(KeyCode.E));
                if (_currentCardIndex >= collectedCards.Count) _currentCardIndex = 0;
                else if (_currentCardIndex < 0) _currentCardIndex = collectedCards.Count-1;
                OnChosenCardChanged?.Invoke(_currentCardIndex);
            }

        }

        private void UseCard()
        {
            if (Input.GetKeyDown(cardUseInput) && _currentCardIndex >= 0)
            {
                Debug.Log(_currentCardIndex.ToString());
                Debug.Log(collectedCards.Count.ToString());
                Card chosenCard = collectedCards[_currentCardIndex];
                playerMovement.MoveSpeed *= chosenCard.SpeedModifier;
                playerMovement.JumpForce *= chosenCard.JumpModifier;
                playerHealth.RecoverHealth(chosenCard.HealthModifier*2);
                playerAttack.AttackStrength += chosenCard.DamageModifier;
                RemoveCard(chosenCard);

                CurrentCardIndex = collectedCards.Count - 1;
            }
        }

        private void AddCad(Card card)
        {
            collectedCards.Add(card);
            OnCollectionModified?.Invoke();
        }

        private void RemoveCard(Card card)
        {
            collectedCards.Remove(card);
            OnCollectionModified?.Invoke();
        }

        public int CurrentCardIndex
        {
            get => _currentCardIndex;
            set
            {
                OnChosenCardChanged?.Invoke(value);
                _currentCardIndex = value;
            } 
        }
    }
    
    
}