using UnityEngine;

[CreateAssetMenu(fileName = "SetOfDialogue", menuName = "Scriptable Objects/SetOfDialogue")]
public class SetOfDialogue : ScriptableObject
{
	[SerializeField] public string[] text;    
}
