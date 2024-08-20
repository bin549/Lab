using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Record {
    public double Acceleration; 
    public double Friction; 
    public double CoF; 
    public double Mass; 
    public double Angle; 
    public double g; 

    public Record(double ac, double q, double ang) {
        Angle = ang;
        Acceleration = ac;
        Mass = q;
        g = System.Math.Abs(Physics.gravity.y);
        getFriction();
    }

    private void getFriction() {
        double Fhe = Acceleration * Mass;
        double f = Mass * g * Math.Sin(Math.PI / 6);
        Friction = Math.Round(f, 4) - Fhe;
        CoF = Friction / (Mass * g * Math.Cos(Math.PI / 6));
    }
}

public class getRecord : MonoBehaviour {
    private bool isaddinterference = false;
    private List<Record> records;
    public Text recordText;

    public double Angle;

    private void Awake() {
        records = new List<Record>();
    }

    public void onInter() {
        isaddinterference = true;
    }

    public void offInter() {
        isaddinterference = false;
    }

    public void cleanRecord() {
        records.Clear();
        recordText.text = "";
    }

    public List<Record> getRecords() {
        return records;
    }

    void updateText(double ac) {
        double mass;
        mass = GameObject.FindWithTag("Cube").GetComponent<Rigidbody>().mass;
    
        if (isaddinterference)
        {
            Random random = new Random();
            double randomAc = random.Next(-10, 10) / 100f;
            print(randomAc);
            records.Add(new Record(ac + (randomAc), mass, Angle));
        }
        else
        {
            records.Add(new Record(ac, mass, Angle));
        }
        recordText.text = "";
        foreach (var record in records)
        {
            
            

            
            recordText.text += String.Format("{0,-20}", Math.Round(record.Acceleration, 3));
            recordText.text += String.Format("{0,-20}", Math.Round(record.Friction, 3));
            recordText.text += String.Format("{0,-20}", Math.Round(record.CoF, 3));
            recordText.text += "\r";
            
            
            
        }
        GameObject
            .FindWithTag("DetailData")
            .gameObject.GetComponent<getDetailData>()
            .updateRecord();
        
    }
}
