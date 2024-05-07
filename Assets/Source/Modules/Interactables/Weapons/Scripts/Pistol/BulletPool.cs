using UnityEngine;
using UnityEngine.Pool;

namespace Modules.Weapons.Scripts
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField, Range(1, 200)] private int _defaultCapacity;
        [SerializeField, Range(10, 500)] private int _maxSize;

        private ObjectPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Bullet>(OnCreate, OnGet, OnRelease, OnBulletDestroy, true, _defaultCapacity, _maxSize);
        }

        public Bullet Get() 
        {
            return _pool.Get();
        }
        
        public void Release(Bullet bullet)
        {
            _pool.Release(bullet);
        }

        private Bullet OnCreate()
        {
            return Instantiate(_bulletPrefab);
        }

        private void OnGet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        private void OnRelease(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnBulletDestroy(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }

        private void OnValidate()
        {
            if(_maxSize < _defaultCapacity)
                _maxSize = _defaultCapacity;
        }
    }
}
