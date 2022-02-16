using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEffect : MonoBehaviour {
	public float TransTime = 0.5f;

	public bool UseSky = true;
	public Material AlternateSky;
	public Material DefaultSky;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			StopAllTransitions();
			StartCoroutine(AltSkyTrans());
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			StopAllTransitions();
			StartCoroutine(DefaultSkyTrans());
		}
	}


	void OnApplicationQuit () {
		RenderSettings.skybox = DefaultSky; 
	}

	void StopAllTransitions () {
		var zoneEffects = GameObject.FindObjectsOfType<ZoneEffect> ();
		foreach (var z in zoneEffects) { 
			z.StopAllCoroutines ();
		}
	}

	IEnumerator AltSkyTrans() {
		float t = 0f;

		while (t < 1.0f) {
			RenderSettings.skybox.Lerp (RenderSettings.skybox, AlternateSky, t);

			t += (TransTime * Time.deltaTime) / 50;

			yield return null;
		}
	}

	IEnumerator DefaultSkyTrans() {
		float t = 0f;

		while (t < 1.0f) {
			//          Debug.Log ("DefaultSkyTrans" + t, this);
			//          print (RenderSettings.skybox + "rendersettings");
			//          print (_defaultSky + "defaultsky");
			RenderSettings.skybox.Lerp (RenderSettings.skybox, DefaultSky, t);

			t += (TransTime * Time.deltaTime) / 50;

			yield return null;
		}
	}
}