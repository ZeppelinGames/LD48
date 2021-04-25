using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Flower : MonoBehaviour
{
    public GameObject[] activate;
    public PostProcessVolume ppVol;
    
    private ColorGrading cg;
    public float fadeSpeed = 5;

    private void Start()
    {
        PostProcessVolume volume = ppVol.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out cg);
    }

    public void PickupFlower()
    {
        foreach(GameObject go in activate)
        {
            go.SetActive(true);
        }
       
        StartCoroutine(fadeCG());
    }

    IEnumerator fadeCG()
    {
        while (cg.saturation.value < 0)
        {
            cg.saturation.value += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}
