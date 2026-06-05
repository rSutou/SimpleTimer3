using UnityEngine;
using UnityEngine.Assertions.Must;

public class TimerUpDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    private TimePlate tp;

    public void UpH()
    {
        tp.Hour += 1;
    }

    public void UpM()
    {
        if(tp.Minute == 59)
        {
            tp.Minute = 0;
        }
        else
        {
            tp.Minute += 1;
        }
    }

    public void UpS()
    {
        if(tp.Second == 59)
        {
            tp.Second = 0;
        }
        else
        {
            tp.Second += 1;
        }
    }

    public void DownH()
    {
        if (tp.Hour > 0)
        {
            tp.Hour -= 1;
        }
    }

    public void DownM()
    {
        if(tp.Minute > 0)
        {
            tp.Minute -= 1;
        }
        else
        {
            tp.Minute = 59;
        }
    }

    public void DownS()
    {
        if (tp.Second > 0)
        {
            tp.Second -= 1;
        }
        else
        {
            tp.Second = 59;
        }
    }
}
