using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDatabase : MonoBehaviour
{

	public List<SoundsListData> soundListData;
    // Start is called before the first frame update
    void Start()
    {
		foreach(SoundsListData soundlist in soundListData)
		{
			soundlist.SetSoundDictionary();
		}
	}

   public SoundsListData GetSoundListsByName (string Name)
	{
		return soundListData.Find(list => list.NameList == Name);
	}

}
