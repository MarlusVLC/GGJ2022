using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Player
{
    public class CardInventory : MonoCache
    {
        [SerializeField] private List<Card> collectedCards;

        // private Card _currentCard;
        private int _currentCardIndex = -1;

        private void Update()
        {
            SelectCards();
        }

        public event Action OnCardCollected;
        public event Action<int> OnChooseCard;
        
        public List<Card> CollectedCards => collectedCards;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Card card) && collectedCards.Count < 5)
            {
                collectedCards.Add(card);
                OnCardCollected?.Invoke();
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
                OnChooseCard?.Invoke(_currentCardIndex);
            }

        }
    }
}