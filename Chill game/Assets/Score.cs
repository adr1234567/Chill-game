using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private List<GameObject> digits = new List<GameObject>();

    public DayNIght time;
    public float score;


    public float letterSpacing;


    void Update()
    {
        PrettyText();
    }

    private void PrettyText()
    {
        int scoreInt = (int)score;
        int digitCount = (int)Mathf.Floor(Mathf.Log10(scoreInt)) + 1;

        foreach (GameObject digit in digits)
        {
            Destroy(digit);
            digits = new List<GameObject>();
        }

        if (scoreInt <= 0)
        {
            GetComponent<TextMeshProUGUI>().text="0";
        }

        for(int i = 0; i < digitCount; i++) {
            //float digitNumber = MathF.Floor(scoreInt/10^(i-1))%10; 
            GetComponent<TextMeshProUGUI>().text="";

            GameObject digit = Instantiate(new GameObject());
            digits.Add(digit);
            digit.transform.parent = gameObject.transform;
            RectTransform rect = digit.AddComponent<RectTransform>();
            digit.AddComponent<CanvasRenderer>();
            TextMeshProUGUI digitText = digit.AddComponent<TextMeshProUGUI>();

            digitText.textWrappingMode = TextWrappingModes.NoWrap;
            digitText.alignment = TextAlignmentOptions.Center;

            rect.position = new Vector3(transform.position.x-(letterSpacing*i)-80+UnityEngine.Random.Range(-digitCount*0.2f, digitCount*0.2f), transform.position.y+(MathF.Sin((time.time*5)+(i*0.2f))*2.5f*digitCount)-(letterSpacing*i/6)+UnityEngine.Random.Range(-digitCount*0.2f, digitCount*0.2f), 0);

            float scale = (Mathf.Sin((time.time*5)+(i*0.2f))+2)*digitCount*0.1f+1;
            rect.localScale = new Vector3(scale, scale, scale);

            digitText.color = new Vector4(1-(Mathf.Sin((time.time*5)+(i*0.2f)+1)*digitCount*0.1f), 1-(Mathf.Sin((time.time*5)+(i*0.2f)+2)*digitCount*0.1f), 1-(Mathf.Sin((time.time*5)+(i*0.2f)+3)*digitCount*0.1f), 1);

            digitText.text = scoreInt.ToString().ToCharArray()[digitCount-i-1].ToString();
        }
    }
}
