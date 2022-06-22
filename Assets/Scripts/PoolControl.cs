using UnityEngine;

public class PoolControl : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private int _poolCount = 5;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Bullet _bulletPrefab;

    private PoolMono<Bullet> _pool;

    private void Start()
    {
        _pool = new PoolMono<Bullet>(_bulletPrefab, _poolCount, transform);
        _pool._autoExpand = _autoExpand;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended)
            {
                Ray ray = _camera.ScreenPointToRay(touch.position);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name != "Player")
                    {
                        SetDirectionToFreeElement(hit.point);
                    }
                }
            }
        }
    }

    private void SetDirectionToFreeElement(Vector3 direction)
    {
        Bullet _bullet = _pool.GetFreeElement();
        _bullet.SetDirection(direction);
    }
}
