using BikeSuperRacing.Domain.Bikes;
using UnityEngine;

namespace BikeSuperRacing.Gameplay.Bike.View
{
    public sealed class BikeColorApplier : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SpriteRenderer[] _targetRenderers;

        [Header("Fallback")]
        [SerializeField] private Color _fallbackColor = Color.red;

        public void ApplyBikeColorDefinition(BikeColorDefinition bikeColorDefinition)
        {
            var targetColor = _fallbackColor;

            if (bikeColorDefinition != null && bikeColorDefinition.TryGetColor(out var parsedColor))
            {
                targetColor = parsedColor;
            }

            ApplyColor(targetColor);
        }

        public void ApplyColor(Color color)
        {
            if (_targetRenderers == null)
            {
                return;
            }

            for (var i = 0; i < _targetRenderers.Length; i++)
            {
                if (_targetRenderers[i] != null)
                {
                    _targetRenderers[i].color = color;
                }
            }
        }
    }
}
