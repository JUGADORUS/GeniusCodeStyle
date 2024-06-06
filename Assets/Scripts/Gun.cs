using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private float _rechargingTime; 

    private WaitForSeconds _waitForSeconds; 

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_rechargingTime);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = true;

        while (isWorking)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            bullet.transform.up = direction;
            bullet.velocity = direction * _speed;

            yield return _waitForSeconds;
        }
    }
}
