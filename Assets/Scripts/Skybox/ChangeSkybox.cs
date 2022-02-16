using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    [SerializeField] private Material skybox;
    [SerializeField] private Material skyboxBlack1;
    [SerializeField] private Material skyboxBlack2;
    [SerializeField] private Material skyboxBlack3;
    [SerializeField] private Material skyboxRed1;
    [SerializeField] private Material skyboxRed2;
    [SerializeField] private Material skyboxRed3;
    private float transitionTime = 0.5f;
    private KeyCode keyCode;
 
	IEnumerator SkyboxTransition(Material newSkybox)
    {
		float t = 0f;

		while (t < 1.0f) {
			RenderSettings.skybox.Lerp (RenderSettings.skybox, newSkybox, t);

			t += (transitionTime * Time.deltaTime) / 50;

			yield return null;
		}
	}

    private void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StopAllCoroutines();
            StartCoroutine(SkyboxTransition(skybox));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopAllCoroutines();
            StartCoroutine(SkyboxTransition(skyboxRed1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StopAllCoroutines();
            StartCoroutine(SkyboxTransition(skyboxRed2));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StopAllCoroutines();
            StartCoroutine(SkyboxTransition(skyboxRed3));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StopAllCoroutines();
            StartCoroutine(SkyboxTransition(skyboxBlack1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StopAllCoroutines();
            StartCoroutine(SkyboxTransition(skyboxBlack2));
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            StopAllCoroutines();
            StartCoroutine(SkyboxTransition(skyboxBlack3));
        }
    }
}
