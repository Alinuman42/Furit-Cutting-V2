using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tryscript : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private float _time = 0;
    public float beginTime;
    private void Start()
    {
        _text.text = "Time:";
        StartCoroutine(startTiming(beginTime));
    }

    IEnumerator startTiming(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            _time += 1;

            _text.text = $"Time: {0}" + _time.ToString();   

        }
    }



}
