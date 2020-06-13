using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AimEnemy))]
public class SwithAI : MonoBehaviour
{

    public enum AIMode
    {
        None, Solider, Ranger
    }
    [SerializeField]
    private AIMode m_AImode = AIMode.None;
    public AIMode AImode
    {
        get { return m_AImode; }
        set
        {
            DisableAllAI();
            m_AImode = value;
            switch (value)
            {
                case AIMode.None:
                    break;
                case AIMode.Solider:
                    soliderAI.enabled = true;
                    break;
                case AIMode.Ranger:
                    rangerAI.enabled = true;
                    break;
                default:
                    break;
            }
        }
    }


    private SoliderAI soliderAI = null;
    private RangerAI rangerAI = null;
    private AimEnemy aimEnemy = null;
    //private float CD = 0.5f;
    private void Awake()
    {
        UpdateRefference();
        AImode = AIMode.None;
    }

    private void Update()
    {
        //if (CD <= 0.0f)
        //{
        //    CD = 0.5f;
        switch (AImode)
        {
            case AIMode.None:
                break;
            case AIMode.Solider:
                if (soliderAI.target == null && rangerAI)
                    AImode = AIMode.Ranger;
                break;
            case AIMode.Ranger:
                if (aimEnemy.AimTarget("Default", soliderAI.searchRange) && soliderAI)
                {
                    AImode = AIMode.Solider;
                }

                break;
            default:
                break;
        }
        //}
        //else CD -= Time.deltaTime;
    }

    private void ArriveTargetReciver()
    {
        if (AImode.Equals(AIMode.None))
        {
            if (soliderAI) AImode = AIMode.Solider;
            if (rangerAI) AImode = AIMode.Ranger;
        }
    }


    private void UpdateRefference()
    {
        soliderAI = GetComponent<SoliderAI>();
        rangerAI = GetComponent<RangerAI>();
        aimEnemy = GetComponent<AimEnemy>();
    }

    private void DisableAllAI()
    {
        if (soliderAI) soliderAI.enabled = false;
        if (rangerAI) rangerAI.enabled = false;
    }

}
