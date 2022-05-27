using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public GameManager _gameManager;
    private bool _isDroppingFast;
    public bool IsDroppingFast => _isDroppingFast;

    // ReSharper disable once UnusedMember.Global
    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (_gameManager.CurrentTetromino == null || !context.performed) return;
        
        var tetromino = _gameManager.CurrentTetromino;
        tetromino.MoveRight(_gameManager.MoveDistance);
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (_gameManager.CurrentTetromino == null || !context.performed) return;

        var tetromino = _gameManager.CurrentTetromino;
        tetromino.MoveLeft(_gameManager.MoveDistance);
    }

    // ReSharper disable once UnusedMember.Global
    public void OnDropFaster(InputAction.CallbackContext context)
    {
        if (_gameManager.CurrentTetromino == null) return;

        if (context.performed)
        {
            _isDroppingFast = true;
        }

        if (context.canceled)
        {
            _isDroppingFast = false;
        }
    }
}
