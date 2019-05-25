using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTest : MonoBehaviour
{
    public string Name;

    public virtual void MakeSound()
    {
        Debug.Log("No sound detected");

    }
    private void Start()
    {
        MakeSound();
    }
}
