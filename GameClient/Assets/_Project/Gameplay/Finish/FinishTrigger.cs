using UnityEngine;

namespace BikeSuperRacing.Gameplay.Finish
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private BikeSuperRacing.Gameplay.RaceFlow.RaceFlowController _raceFlowController;
        [SerializeField] private Rigidbody2D _targetBikeRigidbody2D;

        public void RegisterTargetBike(Rigidbody2D targetBikeRigidbody2D)
        {
            _targetBikeRigidbodyD = targetBikeRigidbody2D;
        }

        private void Reset()
        {
            var collider2D = GetComponent<Collider2D>();

            if (collider2D != null)
            {
                collider2D.isTrigger = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_raceFlowController == null || other == null)
            {
                return;
            }

            if (_targetBikeRigidbody2D != null)
            {
                if (other.attachedRigidbody != _targetBikeRigidbody2D)
                {
                    return;
                }
            }

            _raceFlowController.HandleFinishTriggered();
        }
    }
}
