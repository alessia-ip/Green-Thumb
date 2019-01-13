using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
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

    //collision with triggers (sunlight)
    void OnTriggerStay(Collider trig)
    {
        if (trig.gameObject.name.Contains(sunName))
        {
            //sunlightMeter.value += sAdd;
            sScore += sAdd;
        }

        if (trig.gameObject.name.Contains(waterName))
        {
            //sunlightMeter.value += sAdd;
            wScore += wAdd;
        }
    }

    //collision with rigid bodies
    void OnCollisionEnter (Collision col)
    {
        string colObject = col.gameObject.name;

        //increment water bar
        if(colObject.Contains(waterName))
        {
            Destroy(col.gameObject);
            //waterBar.value += wAdd;
            wScore += wAdd;
        }
/*
        //increment sunlight bar
        if(colObject.Contains(sunName))
        {
            sScore += sAdd;
        }
*/
        if(colObject.Contains(fertilizer))
        {
            Destroy(col.gameObject);
            multiplier = true;
        }

        //hazard
        if(colObject.Contains(hazard))
        {
            //if hazard is destroyed, need to put identifying string in object name
            if(colObject.Contains(destroy))
            {
                Destroy(col.gameObject);
            }
            hScore -= hAdd;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
