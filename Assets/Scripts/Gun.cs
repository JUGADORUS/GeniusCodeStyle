using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private float _rechargingTime; 

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = true;

        while (isWorking)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            bullet.transform.up = direction;

            if (bullet.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.velocity = direction * _speed;
            }

            yield return new WaitForSeconds(_rechargingTime);
        }
    }
}
