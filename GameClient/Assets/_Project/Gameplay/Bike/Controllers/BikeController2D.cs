using BikeSuperRacing.Domain.Bikes;
using UnityEngine;

namespace BikeSuperRacing.Gameplay.Bike.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BikeController2D : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [Header("Fallback Settings")]
        [SerializeField] private float _fallbackAcceleration = 20f;
        [SerializeField] private float _fallbackMaxSpeed = 18f;
        [SerializeField] private float _fallbackHandling = 12f;
        [SerializeField] private float _brakeDeceleration = 24f;

        private float _appliedAcceleration;
        private float _appliedMaxSpeed;
        private float _appliedHandling;

        private void Reset()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Awake()
        {
            if (_rigidbody2D == null)
            {
                _rigidbody2D = GetComponent<Rigidbody2D>();
            }

            ApplyBikeDefinition(null);
        }

        private void FixedUpdate()
        {
            if (_rigidbody2D == null)
            {
                return;
            }

            var accelerationInput = 0f;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                accelerationInput += 1f;
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                accelerationInput -= 1f;
            }

            var currentVelocity = _rigidbody2D.linearVelocity;

            if (accelerationInput > 0f)
            {
                currentVelocity.x += _appliedAcceleration * Time.fixedDeltaTime;
            }
            else if (accelerationInput < 0f)
            {
                currentVelocity.x -= _brakeDeceleration * Time.fixedDeltaTime;
            }
            else
            {
                currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 0f, _brakeDeceleration * 0.35f * Time.fixedDeltaTime);
            }

            currentVelocity.x = Mathf.Clamp(currentVelocity.x, -_appliedMaxSpeed * 0.35f, _appliedMaxSpeed);
            _rigidbody2D.linearVelocity = currentVelocity;
        }

        public void ApplyBikeDefinition(BikeDefinition bikeDefinition)
        {
            _appliedAcceleration = bikeDefinition != null ? bikeDefinition.Acceleration : _fallbackAcceleration;
            _appliedMaxSpeed = bikeDefinition != null ? bikeDefinition.MaxSpeed : _fallbackMaxSpeed;
            _appliedHandling = bikeDefinition != null ? bikeDefinition.Handling : _fallbackHandling;

            _appliedAcceleration = Mathf.Max(0f, _appliedAcceleration);
            _appliedMaxSpeed = Mathf.Max(0.1f, _appliedMaxSpeed);
            _appliedHandling = Mathf.Max(0f, _appliedHandling);
        }

        public void ResetRuntimeState()
        {
            if (_rigidbody2D == null)
            {
                return;
            }

            _rigidbody2D.linearVelocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0f;
            _rigidbody2D.Sleep();
            _rigidbody2D.WakeUp();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _fallbackAcceleration = Mathf.Max(0f, _fallbackAcceleration);
            _fallbackMaxSpeed = Mathf.Max(0.1f, _fallbackMaxSpeed);
            _fallbackHandling = Mathf.Max(0f, _fallbackHandling);
            _brakeDeceleration = Mathf.Max(0f, _brakeDeceleration);
        }
#endif
    }
}
