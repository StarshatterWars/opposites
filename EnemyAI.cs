using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameManager gameManager;
    public enum EnemyType
    {
        EnemyOne,
        EnemyTwo,
        EnemyThree
    }

    public enum EnemyColour
    {
        White,
        Black
    }

    [SerializeField] internal EnemyType enemyType;
    [SerializeField] internal EnemyColour enemyColour;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyType)
        {
            case EnemyType.EnemyOne:
                EnemyOne();
                break;
            case EnemyType.EnemyTwo:
                break;
            case EnemyType.EnemyThree:
                break;
            default:
                break;
        }
    }

    void EnemyOne()
    {
        if(gameManager.playerBlackObj && gameManager.playerWhiteObj != null)
        {
            if (enemyColour == EnemyColour.White)
            {
                transform.LookAt(gameManager.playerBlackObj.transform);
            }
            else if (enemyColour == EnemyColour.Black)
            {
                transform.LookAt(gameManager.playerWhiteObj.transform);
            }
        }
        else
        {
            Debug.LogError("PlayerWhiteObj or PlayerBlackObj has not been set in GameManager");
        }
    }
}
