using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class Distortion : MonoBehaviour
{
    public PostProcessVolume ppProfiel;
     LensDistortion lens;
    Grain grain;
    AutoExposure AE;
    public Calmness calmness;
    // values lens destortion
    private float SVLDintensity = 1;
    private float SVLDxmultiplier = 0;
    private float SVLDymultiplier = 0;
    private float SVLDcenterX = 0;
    private float SVLDcenterY = 0;
   

    private float EVLDintensity = -80;
    private float EVLDxmultiplier = 0.53f;
    private float EVLDymultiplier = 0.55f;
    private float EVLDcenterX = -1;
    private float EVLDcenterY = 0.6f;
    

    private float LDintensity;
    private float LDxmultiplier;
    private float LDymultiplier;
    private float LDcenterX;
    private float LDcenterY;
    

    // values grain
    private float SVGintensity = 0;
    private float SVGsize = 0.3f;
    private float SVGLcontribution = 0;

    private float EVGintensity = 1;
    private float EVGsize = 3;
    private float EVGLcontribution = 1;

    private float Gintensity;
    private float Gsize;
    private float GLcontribution;
    // values auto exposure
    private float SVAEmin = 0;

    private float EVAEmin= 4.3f;

    private float AEmin;
    //===========

    private float startdistance = 15f;
    public Transform player;
    public Transform[] enemys;
    private float[] DF;
    private float low;
    void Start()
    {
     LDintensity = -81 / startdistance;
     LDxmultiplier =0.53f / startdistance;
     LDymultiplier = 0.55f / startdistance;
     LDcenterX = -1/ startdistance;
     LDcenterY = 0.6f/ startdistance;

     Gintensity = 1/ startdistance;
     Gsize = 2.7f/ startdistance;
     GLcontribution = 1/ startdistance;

     AEmin = 4.5f / startdistance;
        DF = new float[enemys.Length];


        ppProfiel.profile.TryGetSettings<LensDistortion>(out lens);
        ppProfiel.profile.TryGetSettings<Grain>(out grain);
        ppProfiel.profile.TryGetSettings<AutoExposure>(out AE);
    }

    // Update is called once per frame
    void Update()
    {
        float min = float.MaxValue;
        int closest = 0;
        for (int i = 0;i < enemys.Length;i++)
        {
            DF[i]= Vector3.Distance(player.position, enemys[i].position);


            if (DF[i] < min)
            {
                min = DF[i];
                closest = i;
            }
        }

        Debug.Log(closest);
        if (min <= 15f)
        {
            calmness.Cmeter = calmness.Cmeter + 1;
            lens.intensity.value = EVLDintensity - (LDintensity * min);
            lens.intensityX.value = EVLDxmultiplier - (LDxmultiplier * min);
            lens.intensityY.value = EVLDymultiplier - (LDymultiplier * min);
            lens.centerX.value = EVLDcenterX - (LDcenterX * min);
            lens.centerY.value = EVLDcenterY - (LDcenterY * min);

            grain.intensity.value = EVGintensity - (Gintensity * min);
            grain.size.value = EVGsize - (Gsize * min);
            grain.lumContrib.value = EVGLcontribution - (GLcontribution * min);

            AE.minLuminance.value = EVAEmin - (AEmin * min);



        }

        //for (int i = 0; i < DF.Length; i++)
        // {

        //  if (DF[i] < low)
        //  {
        //   low = DF[i];

        // }  
        //}



        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dist = Vector3.Distance(player.position,enemys[closest].position);
            Debug.Log(dist);
        }
    }
}
