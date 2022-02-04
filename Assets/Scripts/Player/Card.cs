using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Player
{
    public class Card : MonoBehaviour
    {
        [Range(0.5f,2)][SerializeField] private float speedModifier = 1.0f;
        [Range(0.0f,2)][SerializeField] private float jumpModifier = 1.0f;
        [SerializeField] private int healthModifier;
        [SerializeField] private int damageModifier;

        [Header("UI FEATURES")]
        [SerializeField] private Sprite icon;

        private Image _displayImage;

        private void Awake()
        {
            _displayImage = GetComponentInChildren<Image>();
        }

        public float SpeedModifier => speedModifier;
        public float JumpModifier => jumpModifier;
        public int HealthModifier => healthModifier;
        public int DamageModifier => damageModifier;
        public Sprite Icon => icon;
        public Image DisplayImage => _displayImage;
    }
}