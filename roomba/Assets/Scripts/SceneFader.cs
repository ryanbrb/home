using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{

    public GameObject ImageGameObject1;
    public Image CutsceneImage1;
    public GameObject ImageGameObject2;
    public Image CutsceneImage2;
    public GameObject ImageGameObject3;
    public Image CutsceneImage3;
    public GameObject ImageGameObject4;
    public Image CutsceneImage4;
    public GameObject ImageGameObject5;
    public Image CutsceneImage5;
    public GameObject ImageGameObject6;
    public Image CutsceneImage6;

    private Color CutsceneColor = Color.white;
    bool isChanging1 = false;
    bool isChanging2 = false;
    bool isChanging3 = false;
    bool isChanging4 = false;
    bool isChanging5 = false;
    bool isChanging6 = false;

    public float lerpTime = 0.5f;
    public float CutsceneDelay1;
    public float CutsceneDelay2;
    public float CutsceneDelay3;
    public float CutsceneDelay4;
    public float CutsceneDelay5;
    public float CutsceneDelay6;
    float _timeStartedLerping;
    float timeSinceStarted;



    void Start()
    {

        CutsceneImage1 = ImageGameObject1.GetComponent<Image>();
        CutsceneColor.a = 1f;
        Invoke("ChangeColor", CutsceneDelay1);
        Invoke("ChangeColor2", CutsceneDelay2);
        Invoke("ChangeColor3", CutsceneDelay3);
        Invoke("ChangeColor4", CutsceneDelay4);
        Invoke("ChangeColor5", CutsceneDelay5);
        Invoke("ChangeColor6", CutsceneDelay6);
    }


    void ChangeColor()
    {
        isChanging1 = true;
        //Invoke
        _timeStartedLerping = Time.time;

    }



    void ChangeColor2()
    {
        isChanging2 = true;
        //Invoke
        _timeStartedLerping = Time.time;

    }

    void ChangeColor3()
    {
        isChanging3 = true;
        //Invoke
        _timeStartedLerping = Time.time;

    }

    void ChangeColor4()
    {
        isChanging4 = true;
        //Invoke
        _timeStartedLerping = Time.time;

    }

    void ChangeColor5()
    {
        isChanging5 = true;
        //Invoke
        _timeStartedLerping = Time.time;

    }

    void ChangeColor6()
    {
        isChanging6 = true;
        //Invoke
        _timeStartedLerping = Time.time;

    }

    private void Update()
    {
        if (isChanging1)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(1f, 0f, percentageComplete);
            CutsceneColor.a = currentValue;

            CutsceneImage1.color = CutsceneColor;

            if (currentValue <= 0f)
            {
                isChanging1 = false;
            }
        }
        else if (isChanging2)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(1f, 0f, percentageComplete);
            CutsceneColor.a = currentValue;

            CutsceneImage2.color = CutsceneColor;

            if (currentValue <= 0f)
            {
                isChanging2 = false;
            }
        }
        else if (isChanging3)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(1f, 0f, percentageComplete);
            CutsceneColor.a = currentValue;

            CutsceneImage3.color = CutsceneColor;

            if (currentValue <= 0f)
            {
                isChanging3 = false;
            }
        }
        else if (isChanging4)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(1f, 0f, percentageComplete);
            CutsceneColor.a = currentValue;

            CutsceneImage4.color = CutsceneColor;

            if (currentValue <= 0f)
            {
                isChanging4 = false;
            }

        }
        else if (isChanging5)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(1f, 0f, percentageComplete);
            CutsceneColor.a = currentValue;

            CutsceneImage5.color = CutsceneColor;

            if (currentValue <= 0f)
            {
                isChanging5 = false;
            }
        }
        else if (isChanging6)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(1f, 0f, percentageComplete);
            CutsceneColor.a = currentValue;

            CutsceneImage6.color = CutsceneColor;

            if (currentValue <= 0f)
            {
                isChanging6 = false;
            }
        }


        //public CanvasGroup CutsceneShot;


        //public void FadeOut()
        //{
        //    StartCoroutine(FadeCanvasGroup(CutsceneShot, CutsceneShot.alpha, 0)) ;
        //}

        //public IEnumerator FadeCanvasGroup(SceneFader cg, float start, float end, float lerpTime = 0.5f)
        //{
        //    float _timeStartedLerping = Time.time;
        //    float timeSinceStarted = Time.time - _timeStartedLerping;
        //    float percentageComplete = timeSinceStarted / lerpTime;


        //    while (true)
        //    {
        //        timeSinceStarted = Time.time - _timeStartedLerping;
        //        percentageComplete = timeSinceStarted / lerpTime;

        //        float currentValue = Mathf.Lerp(start, end, percentageComplete);

        //        cg.alpha = currentValue;

        //        if (percentageComplete >= 1) break;

        //        yield return new WaitForEndOfFrame();
        //    }

        //    print("done");

        //}

    }
}

