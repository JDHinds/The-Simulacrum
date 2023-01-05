using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    float naCl;
    float s;
    float fe;
    float cu;
    float ag;
    float sn;
    float au;
    float hg;
    float pb;

    float primaMateria;

    int money;

    public Inventory()
    { }

    public float NaCl
    {
        get { return naCl; }
        set
        {
            if (value >= 0)
            { naCl = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float S
    {
        get { return s; }
        set
        {
            if (value >= 0)
            { s = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float Fe
    {
        get { return fe; }
        set
        {
            if (value >= 0)
            { fe = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float Cu
    {
        get { return cu; }
        set
        {
            if (value >= 0)
            { cu = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float Ag
    {
        get { return ag; }
        set
        {
            if (value >= 0)
            { ag = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float Sn
    {
        get { return sn; }
        set
        {
            if (value >= 0)
            { sn = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float Au
    {
        get { return au; }
        set
        {
            if (value >= 0)
            { au = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float Hg
    {
        get { return hg; }
        set
        {
            if (value >= 0)
            { hg = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float Pb
    {
        get { return pb; }
        set 
        {
            if (value >= 0)
            { pb = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public float PrimaMateria
    {
        get { return primaMateria; }
        set
        {
            if (value >= 0)
            { primaMateria = value; }
            else
            { throw new NotEnoughMaterialException(); }
        }
    }

    public int Money
    {
        get { return money; }
        set { money = value; }
    }
}