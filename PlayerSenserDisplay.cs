using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSenserDisplay : MonoBehaviour
{
	[CustomEditor(typeof(PlayerSenser))]
	public class FieldOfViewEditor : Editor
	{

		void OnSceneGUI()
		{
			PlayerSenser Senser = (PlayerSenser)target;
			Handles.color = Color.white;
			Handles.DrawWireArc(Senser.transform.position, Vector3.forward, Vector2.right, 360, Senser.ViewRadius);
			Vector3 viewAngleA = Senser.DirFromAngle(-Senser.ViewAngle / 2, false);
			Vector3 viewAngleB = Senser.DirFromAngle(Senser.ViewAngle / 2, false);

			Handles.DrawLine(Senser.transform.position, Senser.transform.position + viewAngleA * Senser.ViewRadius);
			Handles.DrawLine(Senser.transform.position, Senser.transform.position + viewAngleB * Senser.ViewRadius);

			Handles.color = Color.red;
			foreach (Transform visibleTarget in Senser.visibleTargets)
			{
				Handles.DrawLine(Senser.transform.position, visibleTarget.position);
			}
		}
	}
}
