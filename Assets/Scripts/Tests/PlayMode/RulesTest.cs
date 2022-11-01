using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RulesTest
{
    [UnityTest]
    public IEnumerator RulesTestOne() {
    
        var rulesObject = new GameObject();
        var cellObject = new GameObject();
        var rules = rulesObject.AddComponent<Rules>();
        cellObject.AddComponent<Cell>();

        rules.putToken(cellObject);



        yield return null;
    }
}
