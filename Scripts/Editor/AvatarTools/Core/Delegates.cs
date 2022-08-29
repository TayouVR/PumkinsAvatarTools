﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pumkin.Core
{
    public static class Delegates
    {
        public delegate void SelectedGameObjectChangeHandler(GameObject newSelection);

        public delegate void SelectedCameraChangeHandler(Camera newCamera);
        public delegate void StringChangeHandler(string newString);
    }
}