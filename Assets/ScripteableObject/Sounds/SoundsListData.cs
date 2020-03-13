using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoundsDatas", menuName = "ScriptableObjects/SoundDataList", order = 1)]

public class SoundsListData : ScriptableObject
{
	public List<SoundsData> Soundsdatas;

	Dictionary<string,List<AudioClip>> Multiplesoundsdatas = new Dictionary<string, List<AudioClip>>();

	public void InitSoundsData()
	{
		foreach(SoundsData data in Soundsdatas)
		{
			Multiplesoundsdatas.Add(data.ListName,data.sounds);
		}
	}

	public AudioClip GetRandomSound(string SoundListName)
	{
		List<AudioClip> sounds = Multiplesoundsdatas[SoundListName];

		return sounds[Random.Range(0, sounds.Count)];
	}
}
