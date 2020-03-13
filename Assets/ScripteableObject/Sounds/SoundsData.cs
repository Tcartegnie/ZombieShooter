using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sounds", menuName = "ScriptableObjects/SoundList", order = 1)]
public class SoundsData : ScriptableObject
{
	public string ListName;
	public List<AudioClip> sounds;	 

}
