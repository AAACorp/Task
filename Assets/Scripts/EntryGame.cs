using UnityEngine;

public class EntryGame : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended)
            {
                _playerMover.SetAbilityToMove();
                gameObject.SetActive(false);
            }
        }
    }
}
