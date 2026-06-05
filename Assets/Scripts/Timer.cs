using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRunning = false;
        m_tpRunning.SetTime(0);
        m_tpNext.SetTime(0);
        m_tpCurrent.SetTime(0);
        m_tpSetting.SetTime(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            currentResidueTime += Time.deltaTime;
            if (currentResidueTime >= 1)
            {
                int now = m_tpRunning.GetTime();
                if (currentResidueTime < now)
                {
                    m_tpRunning.SetTime(now - (int)currentResidueTime);
                    currentResidueTime -= (int)currentResidueTime;
                }
                else
                {
                    while (isRunning && now < currentResidueTime)
                    {
                        m_tpRunning.SetTime(0);
                        currentResidueTime -= now;
                        isRunning = TryNext();
                        now = m_tpRunning.GetTime();
                    }
                }

            }
        }
    }

    private float currentResidueTime = 0;

    [SerializeField]
    private bool isRunning = false;
    [SerializeField]
    public bool isRoop = false;

    [SerializeField]
    private TimePlate m_tpRunning;
    [SerializeField]
    private TimePlate m_tpNext;
    [SerializeField]
    private TimePlate m_tpCurrent;
    [SerializeField]
    private TimePlate m_tpSetting;

    [SerializeField]
    private Toggle m_toggleRoop;



    private Queue<int> schedules = new Queue<int>();


    public void Run()
    {
        currentResidueTime = 0;
        isRunning = true;
    }

    public void Stop()
    {
        isRunning = false;
    }

    public bool TryNext()
    {
        if (isRoop && m_tpCurrent.GetTime() > 0)
        {
            schedules.Enqueue(m_tpCurrent.GetTime());
        }
        if (schedules.TryDequeue(out int next)) {

            m_tpRunning.SetTime(next);
            m_tpCurrent.SetTime(next);
            if (schedules.TryPeek(out int nexnext))
            {
                m_tpNext.SetTime(nexnext);
            }
            else
            {
                m_tpNext.SetTime(0);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Skip()
    {
        currentResidueTime = 0;
        if (isRoop && m_tpCurrent.GetTime() > 0)
        {
            schedules.Enqueue(m_tpCurrent.GetTime());
        }
        if (schedules.TryDequeue(out int next))
        {

            m_tpRunning.SetTime(next);
            m_tpCurrent.SetTime(next);
            if (schedules.TryPeek(out int nexnext))
            {
                m_tpNext.SetTime(nexnext);
            }
            else
            {
                m_tpNext.SetTime(0);
            }
        }
        else
        {
            m_tpNext.SetTime(0);
            m_tpCurrent.SetTime(0);
            m_tpRunning.SetTime(0);
            isRunning = false;
        }
    }

    public void AddSchedule()
    {
        int s = m_tpSetting.GetTime();
        if (s > 0)
        {
            schedules.Enqueue(s);

            m_tpNext.SetTime(schedules.Peek());
        }
    }

    public void SetIsRoop()
    {
        isRoop = m_toggleRoop.isOn;
    }
}
