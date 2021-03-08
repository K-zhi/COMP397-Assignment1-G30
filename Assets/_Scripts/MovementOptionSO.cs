using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementOptions", menuName = "OptionsMenu/MovementOptions")]
public class MovementOptionSO : ScriptableObject
{
    public KeyOption upKey;
    public KeyOption downKey;
    public KeyOption rightKey;
    public KeyOption leftkey;
}

[System.Serializable]
public class KeyOption
{
    public string name;
    public int value;
}

[System.Serializable]
public enum KeyType
{
    KEY,
    ARROW,
    NUMPAD
}