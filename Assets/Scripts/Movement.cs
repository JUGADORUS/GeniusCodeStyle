using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform[] _places;
    [SerializeField] private Transform _point;
    [SerializeField] private float _speed;
    [SerializeField] private int _index;

    private void Start()
    {
        _places = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _places[i] = _point.GetChild(i).transform;
        }
    }

    private void Update()
    {
        Transform point = _places[_index];
        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (transform.position == point.position)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        _index++;

        if (_index == _places.Length)
        {
            _index = 0;
        }

        Vector3 point = _places[_index].transform.position;
        transform.forward = point - transform.position;
    }
}
