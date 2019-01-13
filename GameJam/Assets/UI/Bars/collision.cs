using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
public string waterName = "drop";
public string sunName = "praiseTheSun";
public string fertilizer = "poopy";
public string hazard = "fuckThatHurt";
public string destroy = "KILLITWITHFIRE";


public float wScore = 100f; //water bar
public float sScore = 100f; //sunlight bar
public float hScore = 100f; //wilting status
public bool multiplier = false;

public float wAdd = 10f; //water bar increment
public float sAdd = 10f; //sunlight bar increment
public float hAdd = 10f; //increment wilt status

    sunlightMeterController testfordebug;
    waterMeterController testfordebug2; 
    GameObject slider1 = null;
    GameObject slider2 = null;

    void Start(){

        slider1 = GameObject.FindGameObjectWithTag("Slider1");
        slider2 = GameObject.FindGameObjectWithTag("Slider2");

    }

    private void Update()
    {
       

        testfordebug = slider1.GetComponent<sunlightMeterController>();
        Debug.Log(testfordebug);

        testfordebug2 = slider2.GetComponent<waterMeterController>();
    }

    //collision with triggers (sunlight)
    void OnTriggerStay(Collider trig)
    {
        if (trig.gameObject.name.Contains(waterName))
        {

            testfordebug.increaseSunlight();
            //slider1.GetComponent<waterMeterController>().increaseWater();
        }

        if (trig.gameObject.name.Contains(sunName))
        {

            testfordebug2.increaseWater();

        }

    }

//    //collision with rigid bodies
//    void OnCollisionEnter (Collision col)
//    {
//        string colObject = col.gameObject.name;

//        //increment water bar
//        if(colObject.Contains(waterName))
//        {

//            slider2.GetComponent<sunlightMeterController>().increaseSunlightValue += sAdd;

//        }
///*
//        //increment sunlight bar
//        if(colObject.Contains(sunName))
//        {
//            sScore += sAdd;
//        }
//*/
    //    if(colObject.Contains(fertilizer))
    //    {
    //        Destroy(col.gameObject);
    //        multiplier = true;
    //    }

    //    //hazard
    //    if(colObject.Contains(hazard))
    //    {
    //        //if hazard is destroyed, need to put identifying string in object name
    //        if(colObject.Contains(destroy))
    //        {
    //            Destroy(col.gameObject);
    //        }
    //        hScore -= hAdd;
    //    }
    //}

    // Start is called before the first frame update


    // Update is called once per frame

}
