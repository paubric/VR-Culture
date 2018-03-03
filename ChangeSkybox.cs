using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class ChangeSkybox : MonoBehaviour
{
    public Material[] skyboxes;
    public AudioClip[] bodi;
    private AudioSource[] sound;
    private short crtSkybox = 0;

	void Start ()
    {
        sound = new AudioSource[bodi.Length];
        for (int i = 0; i < bodi.Length; i++)
        {
            sound[i] = gameObject.AddComponent<AudioSource>();
            sound[i].clip = bodi[i];
        }
        RenderSettings.skybox = skyboxes[crtSkybox];
        StartCoroutine(Begin());
    }

    private IEnumerator Begin()
    {
        while (true)
        {
            RenderSettings.skybox = skyboxes[crtSkybox];
            sound[crtSkybox].Play();
            crtSkybox++;


            if (crtSkybox >= skyboxes.Length)
                crtSkybox = 0;

            yield return new WaitForSeconds(bodi[crtSkybox].length);
        }
    }
}
