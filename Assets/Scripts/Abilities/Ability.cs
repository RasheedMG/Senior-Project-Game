using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public Sprite icon;
    public AudioClip soundEffect;

    public virtual void Activate(GameObject parent) { }
    public virtual void Deactivate(GameObject parent) { }
}
