using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sunlightMeterController : MonoBehaviour
{
    private Slider sunlightBar;
    public float decreaseSunlightRate;
    public float increaseSunlightValue;
    public string endGameScene;

    // Start is called before the first frame update
    void Start()
    {
        // Initialsunlight bar percentage 
       sunlightBar = GetComponent<Slider>();
       sunlightBar.maxValue = 100.0f;
       sunlightBar.value = 100.0f;

    }

    // Update is called once per frame
    void Update()
    {
        decreaseSunlight();

        // To increment water
        /*if (Input.GetKey("space"))
        {
            increaseWater();
        }*/
    }

    public void increaseSunlight()
    {
       sunlightBar.value += increaseSunlightValue / 30;
        if (sunlightBar.value >= 100.0f)
        {
           sunlightBar.value = 100.0f;
        }
    }

    void decreaseSunlight()
    {
       sunlightBar.value -= Time.deltaTime * decreaseSunlightRate;
        if (sunlightBar.value <= 0.0f)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        SceneManager.LoadScene(endGameScene);
    }
}
