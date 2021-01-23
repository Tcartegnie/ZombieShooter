using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
public	PlayerMovement playermovement;
public	CharacterShoot playerShoot;

    // Update is called once per frame
    void Update()
    {
        
    }


	public void GetLateralDirectionValue()
	{
		Vector3.Dot(playerShoot.GetShootDirection(), playermovement.GetLateralDirection(Input.GetAxis("Horizontal")));
	}

	public void GetForwardDirectionValue()
	{

	}
}
