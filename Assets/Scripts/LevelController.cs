using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private PlayerMover _playerMover;

    private LevelController _selfController;
    public void RemoveFromList(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }

    void Start()
    {
        _selfController = GetComponent<LevelController>();

        for(var i = 0; i < transform.childCount; i++)
        {
            _enemies.Add(transform.GetChild(i).GetComponent<Enemy>());
        }
    }

    void Update()
    {
        if (_enemies.Count <= 0)
        {
            _playerMover.SetAbilityToMove();
            _selfController.enabled = false;
        }
    }
}
