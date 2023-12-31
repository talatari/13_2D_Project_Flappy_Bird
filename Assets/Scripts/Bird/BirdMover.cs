using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _minRotationZ;
        [SerializeField] private float _maxRotationZ;
        
        private Vector3 _startPosition;
        private Rigidbody2D _rigidbody;
        private Quaternion _minRotation;
        private Quaternion _maxRotation;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            
            ResetPosition();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.velocity = new Vector2(_speed, 0);
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);

                transform.rotation = _maxRotation;
            }
            
            if (transform.rotation.z > _maxRotation.z)
                transform.rotation = _maxRotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, Time.deltaTime * _rotationSpeed);
        }

        public void ResetPosition()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.identity;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}