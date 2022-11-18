using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{

    [Test]
    public void AnimationTeat()
    {

        GameObject player= Resources.Load("Prefabs/Player") as GameObject;
        player = Object.Instantiate(player);
        
        
    }
    
    
}
