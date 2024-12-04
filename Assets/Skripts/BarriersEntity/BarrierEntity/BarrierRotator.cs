using UnityEngine;

namespace BarrierEntity
{
    public class BarrierRotator : MonoBehaviour
    {
        private Vector3 _rotation;
        private float _speedRotate = 700;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            SetNormalSpeed();
        }

        private void Update()
        {
            RotateBarrier();
        }

        public void SetSpeed(int speedRotate)
        {
            _rotation = new Vector3(0, 0, _speedRotate * speedRotate);
        }

        public void SetNormalSpeed()
        {
            _rotation = new Vector3(0, 0, _speedRotate);
        }

        private void RotateBarrier()
        {
            _transform.Rotate(_rotation * Time.deltaTime);
        }
    }
}