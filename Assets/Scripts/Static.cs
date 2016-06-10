using UnityEngine;
using System.Collections;

public static class Static{
	
	public static int controlOption = 2;
	public static int GetControlOption(){
		return controlOption;
	}
	
	public static void SetControlOption(int value){
		controlOption = value;
	}
}
