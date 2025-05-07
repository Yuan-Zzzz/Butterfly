using System;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using QFramework.Example;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public void OnMouseDown()
    {
        UIKit.OpenPanel<UIChessBorad>();

        GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
