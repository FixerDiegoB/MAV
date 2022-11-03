using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status { EMPTY, WHITE, BLACK };
public enum GamePhase { PUT, MOVE};

public class Board : MonoBehaviour
{
    public List<Cell> cells;
    public List<Mill> mills;
    [HideInInspector]
    public List<Token> whiteTokens, blackTokens;
    [HideInInspector]
    public int totalTokens, numWhiteTokens, numBlackTokens;

    private void Start()
    {
        totalTokens = numWhiteTokens = numBlackTokens = 0;
    }

}
