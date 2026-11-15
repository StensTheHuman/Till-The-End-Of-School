using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum UpgrateType
{
    Common,
    Personal
}

[CreateAssetMenu(fileName = "Upgrates", menuName = "Scriptable Objects/Upgrates")]

public class Upgrates : ScriptableObject
{
    public UpgrateType type;
    public bool isAutomatic;
    public float scoreMultiplayer;
    public float cost;
    public Sprite icon;
    public string description;
}
