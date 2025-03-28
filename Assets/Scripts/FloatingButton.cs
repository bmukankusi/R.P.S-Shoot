using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// FloatingButton script to make a button float up and down continuously
/// Uses DOTween for smooth transitions
/// </summary>
public class FloatingButton : MonoBehaviour
{
    public float floatDistance = 10f; // Distance to move up and down
    public float floatDuration = 1.5f; // Time for one float cycle

    /// <summary>
    /// Start is called before the first frame update
    /// Make the button float up and down continuously with a smooth transition
    /// </summary>
    void Start()
    {
        transform.DOLocalMoveY(transform.localPosition.y + floatDistance, floatDuration)
            .SetEase(Ease.InOutSine) 
            .SetLoops(-1, LoopType.Yoyo); // Infinite loop up and down
    }
}
