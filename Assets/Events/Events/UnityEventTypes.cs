﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class UnityEventFloat : UnityEvent<float>
{

}

[System.Serializable]
public class UnityEventInt : UnityEvent<int>
{

}

[System.Serializable]
public class UnityEventUnityObject : UnityEvent<UnityEngine.Object>
{

}