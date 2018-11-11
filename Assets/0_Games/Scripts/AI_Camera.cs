using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.PostProcessing;

public class AI_Camera : MonoBehaviour
{
    public PostProcessingProfile postProcProf;

    public float speed = 1;
    void Update()
    {

        var chromaticAberration = postProcProf.chromaticAberration.settings;
        chromaticAberration.intensity = (Mathf.Sin(Time.time * speed) + 1) / 2;

        postProcProf.chromaticAberration.settings = chromaticAberration;
    }

}
