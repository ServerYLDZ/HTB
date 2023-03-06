using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotNumber;
    [SerializeField] GameObject PrefabDot;
    [SerializeField] GameObject ParentDot;
    [SerializeField] float DorSpacing;

    Transform[] dotList ;
    Vector2 pos;
    float timestamp;

    void Start()
    {
        Hide();
        PrepereDotlist();
       
    }
    void PrepereDotlist()
    {
        dotList = new Transform[dotNumber];

        for (int i = 0; i < dotNumber;i++)
        {
            dotList[i] = Instantiate(PrefabDot, null).transform;
            dotList[i].parent = ParentDot.transform;

        }

    }
    public void  UpdateDots(Vector3 ballposition,Vector2 force)
    {
        
        timestamp = DorSpacing;
        for (int i = 0; i < dotNumber; i++)
        {
            pos.x = (ballposition.x +  force.x * timestamp);
            pos.y = (ballposition.y + force.y * timestamp);
            dotList[i].position=pos;
            timestamp += DorSpacing;
            
           
        }
       

    }

    public void Hide()
    {
        ParentDot.SetActive(false);
    }
    public void Show()
    {
        ParentDot.SetActive(true);
    }
 
}
