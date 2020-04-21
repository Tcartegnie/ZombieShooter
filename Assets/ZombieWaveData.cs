using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ZombieWave", menuName = "ScriptableObjects/ZombieWave", order = 1)]
public class ZombieWaveData : ScriptableObject
{
	public List<ZombieType> type;
}
