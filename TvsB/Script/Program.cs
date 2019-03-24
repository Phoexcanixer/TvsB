using System;
using System.Collections.Generic;
using UnityEngine;
using TaengvsBug.Script;

namespace TaengvsBug
{
    class Program : MonoBehaviour
    {

        public void Awake()
        {
            IUser userInput = new UserInput();
        }
    }
}
