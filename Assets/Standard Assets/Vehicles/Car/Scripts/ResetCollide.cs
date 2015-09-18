using UnityEngine;
using System.Collections;

public class ResetCollide : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "ResetCollision")
		{
			Application.LoadLevel ("4ImageTargets");
	}
}
}