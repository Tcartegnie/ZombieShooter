using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoundsDatas", menuName = "ScriptableObjects/SoundDataList", order = 1)]

public class SoundsListData : ScriptableObject
{
	public string NameList;
	public List<SoundsData> Soundsdatas;

	Dictionary<string,List<AudioClip>> Multiplesoundsdatas = new Dictionary<string, List<AudioClip>>();


	public void SetSoundDictionary()
	{
		foreach (SoundsData sound in Soundsdatas)
		{
			Multiplesoundsdatas.Add(sound.ListName, sound.sounds);
		}
	}

	public AudioClip GetRandomSound(string SoundListName)
	{
		List<AudioClip> sounds = Multiplesoundsdatas[SoundListName];

		return sounds[Random.Range(0, sounds.Count)];
	}

	public SoundsData GetSoundListByName(string listName)
	{
		return Soundsdatas.Find(list => list.ListName == listName);
	}
}
