using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _lifeTime = 2f;

    private Vector3 _direction;

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnEnable()
    {
        transform.position = transform.parent.position;

        StartCoroutine("LifeRoutine");
    }

    private void OnDisable()
    {
        StopCoroutine("LifeRoutine");
    }

    private void Update()
    {
        transform.LookAt(_direction);

        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("has collision with " + collision.collider.name);
        if(collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.GetDamage(_damage);
        }

        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);

        Deactivate();
    }
}
