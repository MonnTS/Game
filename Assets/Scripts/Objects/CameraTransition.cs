using UnityEngine;

namespace Objects
{
    public class CameraTransition : MonoBehaviour
    {
        #region FIELDS

#pragma warning disable 0649
        [SerializeField] private Vector2 cameraChange;
        [SerializeField] private Vector3 playerChange;
        private CameraFollow _cameraFollow;
        [SerializeField] private GameObject player;
#pragma warning restore 0649

        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            _cameraFollow = Camera.main?.GetComponent<CameraFollow>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.CompareTag("Player")) return;

            _cameraFollow.minPosition += cameraChange;
            _cameraFollow.maxPosition += cameraChange;
            other.transform.position += playerChange;
        }

        #endregion
    }
}