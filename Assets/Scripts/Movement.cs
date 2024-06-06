using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _points;
    [SerializeField] private float _speed;
    [SerializeField] private int _index;

    private Transform[] _places;

    private void Start()
    {
        _places = new Transform[_points.childCount];

        for (int i = 0; i < _places.Length; i++)
        {
            _places[i] = _points.GetChild(i);
        }
    }

    private void Update()
    {
        Transform point = _places[_index];
        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (transform.position == point.position)
        {
            SetNextPoint();
        }
    }

    private void SetNextPoint()
    {
        _index = (_index + 1) % _places.Length;

        Vector3 point = _places[_index].transform.position;
        transform.forward = point - transform.position;
    }
}
