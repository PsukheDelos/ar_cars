using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {


	public void ChangeToScene (int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);

	}
}
