using System;
using UnityEngine.EventSystems;
using Utilities;

namespace Player
{
    public class CardInventory : MonoCache
    {
        private Card[] collectedCards;
        
        public event Action<Card> OnCardCollected;
        
    }
}