using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public GameManager _gameManager;
    
    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (_gameManager.CurrentTetromino == null || !context.performed) return;
        
        var tetromino = _gameManager.CurrentTetromino;
        tetromino.MoveRight(_gameManager.MoveDistance);
    }
    
    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (_gameManager.CurrentTetromino == null || !context.performed) return;

        var tetromino = _gameManager.CurrentTetromino;
        tetromino.MoveLeft(_gameManager.MoveDistance);
    }
}
