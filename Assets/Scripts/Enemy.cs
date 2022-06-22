using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _hp = 100f;
    [SerializeField] private Image _bar;
    public void GetDamage(float damage)
    {
        _hp -= damage;
    }

    private void Update()
    {
        _bar.fillAmount = _hp / 100;

        if (_hp <= 0)
        {
            transform.parent.GetComponent<LevelController>().RemoveFromList(GetComponent<Enemy>());
            Destroy(gameObject);
        }
    }
}
