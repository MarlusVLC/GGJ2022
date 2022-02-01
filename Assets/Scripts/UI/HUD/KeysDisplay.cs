using TMPro;
using UnityEngine;

namespace UI.HUD
{
    public class KeysDisplay : MonoBehaviour
    {
        [SerializeField] private OpenDoor _openDoor;
        private TextMeshProUGUI keyCounter;

        private void Awake()
        {
            keyCounter = GetComponentInChildren<TextMeshProUGUI>();
            if (!_openDoor)
            {
                _openDoor = FindObjectOfType<OpenDoor>();
            }

            _openDoor.OnCollectKey += UpdateCounter;
            UpdateCounter(_openDoor.keysCollected);


        }

        private void UpdateCounter(int value)
        {
            keyCounter.text = $"{value.ToString()}/{_openDoor.KeysToCollect.ToString()}";
        }
    }
}