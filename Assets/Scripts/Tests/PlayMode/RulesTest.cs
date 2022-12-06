using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RulesTest
{
    [UnityTest]
    public IEnumerator ColocacionPrimeraPieza() { // AC 4.1

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
}
