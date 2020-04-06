using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject Player;
	// Start is called before the first frame update
	void Awake()
    {
		DontDestroyOnLoad(gameObject);
	}

	/*
	 Charger la scéne de jeu avec le personnage du joueur deja instancié 
	 Mettre tout les données de chargement du niveau dans un scriptable object

	 */
}
