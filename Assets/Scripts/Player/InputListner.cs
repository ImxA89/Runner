using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class InputListner : MonoBehaviour
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _playerMover.TryMoveUp();

        if (Input.GetKeyDown(KeyCode.S))
            _playerMover.TryMoveDown();
    }
}
