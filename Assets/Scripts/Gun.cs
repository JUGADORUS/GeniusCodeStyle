using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private float _rechargingTime; 

    private WaitForSeconds _waitForSeconds; 

    private void Start()
    {
        StartCoroutine(Shoot());

        _waitForSeconds = new WaitForSeconds(_rechargingTime);
    }

    private IEnumerator Shoot()
    {
        bool isWorking = true;

        while (isWorking)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            bullet.transform.up = direction;

            if (bullet.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.velocity = direction * _speed;
            }

            yield return _waitForSeconds;
        }
    }
}
