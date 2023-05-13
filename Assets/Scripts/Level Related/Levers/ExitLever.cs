using System.Collections;
using System.Collections.Generic;
using O3DWB;
using UnityEditor;
using UnityEngine;

public class ExitLever : Lever
{
    [SerializeField] private LevelCompleter levelCompleter;

    public override void Interact()
    {
        if (!playerIsWithinRange)
            return;
        
        base.Interact();
        levelCompleter.OpenExit();
        Disable();
    }
}
