using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class PlayerPrefsTools : MonoBehaviour {
	#if UNITY_EDITOR
	[MenuItem("Custom/ResetPlayerPrefs")]
	#endif
	public static void ResetPlayerPrefs() {
		PlayerPrefs.DeleteAll ();
	}
}
