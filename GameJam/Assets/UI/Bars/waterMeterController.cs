using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class waterMeterController : MonoBehaviour
{

    private Slider waterBar;
    public float decreaseWaterRate;
    public float increaseWaterValue;
    public string endGameScene;


    // Start is called before the first frame update
    void Start()
    {
        // Initial water bar percentage 
        waterBar = GetComponent<Slider>();
        waterBar.maxValue = 100.0f;
        waterBar.value = 100.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        decreaseWater();

       
    }

    public void increaseWater()
    {
        waterBar.value += increaseWaterValue / 30;
        if(waterBar.value >= 100.0f)
        {
            waterBar.value = 100.0f;
        }
    }

    void decreaseWater()
    {
        waterBar.value -= Time.deltaTime * decreaseWaterRate ;
        if(waterBar.value <= 0.0f)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        SceneManager.LoadScene(endGameScene);
    }

}
