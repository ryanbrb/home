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
    private static Color _BatteryColor;
    public static Color BatteryColor
    {
        get { return _BatteryColor; }
        set
        {
            if(_BatteryColor != value)
            {
                if(value == Yellow)
                {
                    Instance.WarningSounds(true);
                }else if(value == Red)
                {
                    Instance.WarningSounds(false);
                }
            }
            _BatteryColor = value;
        }
    }
    public float BatteryTimer;
   

    public static Color Green;
    public static Color Yellow;
    public static Color Red;
    private static BatteryUI Instance;

    private AudioSource BatterySounds;
    public AudioClip YellowAlert;
    public AudioClip RedAlert;

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
                    BatteryColor = Green;

                }else if (value <= 0.3f && value > 0.1f) // Change to yellow
                {
                    BatteryColor = Yellow;

                }else if (value <= 0.1f && value > 0f) // Change to red
                {
                    BatteryColor = Red;
                    LevelManager.CallEvent(GameEvent.Warning);

                }
                else if(value <= 0f) // Intiate game over
                {
                    LevelManager.CallEvent(GameEvent.BatteryDead);

                }else
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

        // Sets starting BatteryLife
        BatteryLife = 1f;
        Instance = this;

        BatterySounds = GetComponent<AudioSource>();

    }

    public void WarningSounds(bool yellow)
    {

        BatterySounds.PlayOneShot(yellow ? YellowAlert : RedAlert);


    }
	private float multiplier = 1;
	public static void Drain()
	{
		Instance.multiplier = 2;
	}

	// Update is called once per frame
	void Update()
    {
   

        // Reads current BatteryPower
        BatteryPower.value = BatteryLife;

        // Sets current BatteryColor
        BatteryFill.color = BatteryUI.BatteryColor;

        // BatteryTimer increasing
        BatteryTimer += (Time.deltaTime * multiplier);

        // Converts BatteryTimer to countdown. Maximum time is the denominator of BatteryTimer
        BatteryLife = 1 - (BatteryTimer / 60);
		if(BatteryLife <= 0)
		{
			LevelManager.CallEvent(GameEvent.BatteryDead);
		}

    }
}
