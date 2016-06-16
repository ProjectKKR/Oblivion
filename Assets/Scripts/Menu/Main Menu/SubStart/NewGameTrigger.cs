using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewGameTrigger : MonoBehaviour {
	public void Trigger(){
		int tmp = 1;
		if (PlayerPrefs.HasKey ("Control_Option")) {
			tmp = PlayerPrefs.GetInt ("Control_Option");
		}
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt ("Control_Option", tmp);
		Static.SetControlOption (tmp);
		SceneManager.LoadScene("BACCHUS");
	}
}
