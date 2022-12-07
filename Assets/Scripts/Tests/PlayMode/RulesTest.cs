using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RulesTest
{
    [UnityTest]
    public IEnumerator ColocacionPrimeraPieza() // AC 4.1
    {
        var rulesObject = new GameObject();
        var boardObject = new GameObject();
        rulesObject.AddComponent<Rules>();
        boardObject.AddComponent<Board>();
        Rules rules = rulesObject.GetComponent<Rules>();
        Board board = boardObject.GetComponent<Board>();

        rules.board = board;

        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual(Status.WHITE, rules.turn);

        yield return null;
    }

    [UnityTest]
    public IEnumerator ColocacionExitosaPieza() // AC 4.2
    { 
        var rulesObject = new GameObject();
        var boardObject = new GameObject();
        rulesObject.AddComponent<Rules>();
        boardObject.AddComponent<Board>();
        Rules rules = rulesObject.GetComponent<Rules>();
        Board board = boardObject.GetComponent<Board>();
        List<Cell> cells = new List<Cell>();
        int numCells = 24;

        for (int i = 0; i < numCells; i++)
        {
            var cellObject = new GameObject();
            cellObject.AddComponent<Cell>();
            Cell cell = cellObject.GetComponent<Cell>();
            cells.Add(cell);
        }

        int randCell = Random.Range(0, numCells);

        board.cells = cells;
        rules.board = board;

        Cell selectedCell = board.cells[randCell];
        rules.putToken(selectedCell.gameObject);
        Token token = board.whiteTokens[0];

        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(true, selectedCell.token == token);

        yield return null;
    }
}
