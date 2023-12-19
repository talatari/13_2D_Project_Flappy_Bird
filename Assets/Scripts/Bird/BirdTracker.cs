using UnityEngine;

namespace Scripts
{
    public class BirdTracker : MonoBehaviour
    {
        [SerializeField] private Bird _bird;
        [SerializeField] private float _offsetX;

        private void OnValidate()
        {
            if (_bird == null)
                _bird = FindObjectOfType<Bird>();
        }

        private void Update()
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(_bird.transform.position.x - _offsetX, position.y, position.z);
        }

    }
}