using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    public Image BatteryFill;
    public Color myGreen;
    public Color myYellow;
    public Color myRed;
    public Slider BatteryPower; 
    public static float countdown = 0.5f;
    public static Color BatteryColor;
   

    public static Color Green;
    public static Color Yellow;
    public static Color Red;

    protected static float _BatteryLife;
    public static float BatteryLife
       

    {

        get {
            return _BatteryLife;
        }

        set {

            // Error correction to set numbers larger than the maximum value
            // to the maximum value


            if (value > 1.0f)
            {
                _BatteryLife = 1.0f;

            }else if (value < 0f)
            {
                _BatteryLife = 0f;

            }else // Changes battery color based on value
            {


                if (value > 0.3f) // Change to green
                {
                    Debug.Log("Hello!");
                    BatteryColor = Green; //new Color(0, 231, 0, 255); 

                }else if (value <= 0.3f && value > 0.1f) // Change to yellow
                {
                    BatteryColor = Yellow; //new Color(246, 220, 2, 255);

                }else if (value <= 0.1f && value >= 0f) // Change to red
                {
                    BatteryColor = Red; //new Color(236, 0, 9, 255);

                }
                else
                {
                }
                _BatteryLife = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Green = myGreen;
        Yellow = myYellow;
        Red = myRed;
        BatteryPower = GetComponent<Slider>();

    }
    public float b;
    // Update is called once per frame
    void Update()
    {
        // Sets BatteryLife
        BatteryLife = 0.05f;

        // Sets the BatteryPower at the start. This will be tied to a variable.
        BatteryPower.value = BatteryLife;

        BatteryFill.color = BatteryUI.BatteryColor;
        //BatteryUI.BatteryColor;
    }
}
