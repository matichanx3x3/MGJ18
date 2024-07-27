using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogos", menuName = "ScriptableObjects/Dialogos", order = 1)]
public class TextSpeakOver : ScriptableObject
{
    [TextArea  (4,4)]
    public string[] sentences;
}

