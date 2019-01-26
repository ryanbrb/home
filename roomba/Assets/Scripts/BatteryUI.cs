using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{

    public Slider BatteryPower; 
    public static float countdown = 0.5f;
    public Color BatteryColor;

    protected static float _BatteryLife;
    public static float BatteryLife
       

    {

        get {
            return _BatteryLife;
        }

        set {

            // Error correction to set numbers larger than the maximum value
            // to the maximum value
            // also changes battery fill color as it gets lower

            if(value > 1.0f)
            {
                _BatteryLife = 1.0f;

                }else if(value < 0f)
                {

                _BatteryLife = 0f;

                }else
                {


                _BatteryLife = value;

                }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BatteryPower = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        // Sets maxValue
        BatteryLife = 2.0f;

        // Sets the BatteryPower at the start. This will be tied to a variable.
        BatteryPower.value = BatteryLife;

        // Function to change battery fill color as it gets lower
        // Green when BatteryPower > 0.3,
        // Yellow when BatteryPower <= 0.3 and BatterPower < 0.1
        // Red when BatterPower <= 0.1
        

    }
}
