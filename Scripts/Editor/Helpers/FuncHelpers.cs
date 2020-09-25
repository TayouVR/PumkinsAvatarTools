﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pumkin.AvatarTools.Helpers
{
    public static class FuncHelpers
    {
        public static TReturn InvokeWithoutUnityLogger<TReturn>(Func<TReturn> func)
        {
            TReturn result;
            bool logsEnabled = Debug.unityLogger.logEnabled;
            Debug.unityLogger.logEnabled = false;
            result = func.Invoke();
            Debug.unityLogger.logEnabled = logsEnabled;
            return result;
        }
    }
}
