using System.Collections;
using UnityEngine;

namespace Modules.Weapons.Scripts
{
    [RequireComponent(typeof(BulletPool))]
    public class Shooter : MonoBehaviour, IShooter
    {
        [SerializeField, Range(1, 50)] private float _bulletSpeed;
        [SerializeField, Range(1, 50)] private float _bulletLifeTime;

        private BulletPool _pool;

        private void Awake() => _pool = GetComponent<BulletPool>();

        public void Shoot()
        {
            Bullet bullet = _pool.Get();
            bullet.transform.position = transform.position;
            bullet.Rigidbody.velocity = transform.forward * _bulletSpeed;
            StartCoroutine(ReleaseBulletWithDelay(_bulletLifeTime, bullet));
        }

        private IEnumerator ReleaseBulletWithDelay(float delay, Bullet bullet) 
        {
            yield return new WaitForSeconds(delay);
            _pool.Release(bullet);
        }
    }
}
