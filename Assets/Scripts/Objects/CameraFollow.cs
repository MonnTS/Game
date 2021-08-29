using UnityEngine;

namespace Objects
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        private float _followSpeed;
        public Vector2 maxPosition;
        public Vector2 minPosition;

        private void Start()
        {
            _followSpeed = .2f;
            maxPosition.x = -0.07f;
            maxPosition.y = 10f;
            minPosition.x = -0.07f;
            minPosition.y = 10f;
        }

        private void LateUpdate()
        {
            if (transform.position == target.position) return;
            var position = target.position;
            var cameraPosition = transform.position;
            var targetPosition = new Vector3(position.x, position.y, cameraPosition.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            
            cameraPosition = Vector3.Lerp(cameraPosition, targetPosition, _followSpeed);
            transform.position = cameraPosition;
        }
    }
}