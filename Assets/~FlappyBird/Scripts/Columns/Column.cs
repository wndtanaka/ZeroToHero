﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Column : MonoBehaviour
    {
        // check if the column is 
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.name.StartsWith("Bird"))
                GameManager.Instance.BirdScored();
        }
    }
}