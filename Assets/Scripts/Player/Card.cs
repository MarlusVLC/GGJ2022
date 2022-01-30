using UnityEngine;
using Utilities;

namespace Player
{
    public class Card : MonoBehaviour
    {
        [Range(0,1)][SerializeField] private float speedModifier;
        [SerializeField] private int healthModifier;
        [Range(-1,1)][SerializeField] private int jumpModifier;
        [SerializeField] private int damageModifier;

        [Header("UI FEATURES")]
        [SerializeField] private Sprite icon;

        public float SpeedModifier => speedModifier;
        public int HealthModifier => healthModifier;
        public int JumpModifier => jumpModifier;
        public int DamageModifier => damageModifier;
        public Sprite Icon => icon;
    }
}