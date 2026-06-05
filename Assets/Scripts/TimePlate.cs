using TMPro;
using UnityEngine;

public class TimePlate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hour++;
        Hour--;
        minute++;
        Minute--;
        second++;
        Second--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [SerializeField]
    private TextMeshProUGUI m_textH;
    [SerializeField]
    private TextMeshProUGUI m_textM;
    [SerializeField]
    private TextMeshProUGUI m_textS;


    private int hour = 0;
    private int minute = 0;
    private int second = 0;
    public int Hour
    {
        get { return hour; }
        set
        {
            if (hour != value)
            {
                hour = value;
                m_textH.text = value.ToString("D2");
            }
        }
    }

    public int Minute
    {
        get { return minute; }
        set
        {
            if (minute != value)
            {
                minute = value;
                m_textM.text = value.ToString("D2");
            }
        }
    }

    public int Second
    {
        get { return second; }
        set
        {
            if (second != value)
            {
                second = value;
                m_textS.text = value.ToString("D2");
            }
        }
    }

    public void SetTime(int t)
    {
        Second = t % 60;
        t /= 60;
        Minute = t % 60;
        t /= 60;
        Hour = t;
    }

    public int GetTime()
    {
        return (hour * 60 + minute) * 60 + second;
    }
}
