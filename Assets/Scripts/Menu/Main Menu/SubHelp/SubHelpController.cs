using UnityEngine;
using System.Collections;

public class SubHelpController : MonoBehaviour {

	const int N=6;
	public GameObject[] helps = new GameObject[N];
	int current;
	void Start () {
		for (int i = 1; i < N; i++)
			helps [i].SetActive (false);
		helps [0].SetActive (true);
		current = 0;
	}

	public void Next(){
		if (current == N - 1)
			return;
		helps [current].SetActive (false);
		helps [current + 1].SetActive (true);
		current++;
	}

	public void Prev(){
		if (current == 0)
			return;
		helps [current].SetActive (false);
		helps [current - 1].SetActive (true);
		current--;
	}
}
