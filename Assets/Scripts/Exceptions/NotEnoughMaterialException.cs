using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughMaterialException : Exception
{
    public NotEnoughMaterialException() : base()
    { }

    public NotEnoughMaterialException(string exception) : base(exception)
    { }
}
