using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool gamePasued;
    [SerializeField] internal GameObject playerBlackObj;
    [SerializeField] internal GameObject playerWhiteObj;

    public enum GameState
    {
        Menu,
        GameStart,
        NextLevel
    }

    GameState state;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        if (!GameManager.gamePasued)
        {

            switch (newState)
            {
                case GameState.Menu:
                    break;
                default:
                    break;
            }
        }

    }
}
