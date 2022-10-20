using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    ArcadeKart playerKart;

    [SerializeField]
    List<Transform> levelCheckpoints;


    void Start()
    {
        int PointCount = levelCheckpoints.Count;

        if (!playerKart)
        {
            playerKart = FindObjectOfType<ArcadeKart>();
        }

        for (int i = 0; i < PointCount; i++)
        {   
            int iN = (i + 1) % PointCount;
            float x = levelCheckpoints[iN].transform.position.x - levelCheckpoints[i].transform.position.x;
            float z = levelCheckpoints[iN].transform.position.z - levelCheckpoints[i].transform.position.z;
            
            TrackPointLength += Mathf.Sqrt(x * x + z * z);
        }
    }

    public float procent = 0;
    public static float TraveledLength = 0;
    public float TrackPointLength = 0;
    public int n = 0;

    void Update()
    {
        int PointCount = levelCheckpoints.Count;

        int Nn = (n + 1) % PointCount;
        int Pn = (PointCount + n - 1) % PointCount;

        float playerx = playerKart.transform.position.x;
        float playerz = playerKart.transform.position.z;

        float kartx = playerx - levelCheckpoints[n].transform.position.x;
        float kartz = playerz - levelCheckpoints[n].transform.position.z;
        float KartLength = Mathf.Sqrt(kartx * kartx + kartz * kartz);

        float x = levelCheckpoints[Nn].transform.position.x - levelCheckpoints[n].transform.position.x;
        float z = levelCheckpoints[Nn].transform.position.z - levelCheckpoints[n].transform.position.z;
        float CheckPointLength = Mathf.Sqrt(x * x + z * z);


        float Px = levelCheckpoints[n].transform.position.x - levelCheckpoints[Pn].transform.position.x;
        float Pz = levelCheckpoints[n].transform.position.z - levelCheckpoints[Pn].transform.position.z;
        float pastLength = Mathf.Sqrt(Px * Px + Pz * Pz);

        float Pkartx = playerx - levelCheckpoints[Pn].transform.position.x;
        float Pkartz = playerz - levelCheckpoints[Pn].transform.position.z;
        float pastKartLength = Mathf.Sqrt(Pkartx * Pkartx + Pkartz * Pkartz);


        float addedProcent = KartLength / TrackPointLength;


        if (pastKartLength < pastLength)
        {
            n = (PointCount + n - 1) % PointCount;
            procent -= pastLength / TrackPointLength;
        }

        if (KartLength > CheckPointLength)
        {
            n = (n + 1) % PointCount;
            procent += CheckPointLength / TrackPointLength;
        }

        TraveledLength = procent + addedProcent;

        Debug.Log(TraveledLength);
        Debug.Log(n);
       // Debug.Log(time);

    }
}
