﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace lux.logic
{
    class Qlogic
    {
        public static void simpleQ(Obj_AI_Base target)
        {
            if (Spells.Q.GetPrediction(target).HitChancePercent >= Extension.GetSliderValue(Meniu.Prediction, "q.prediction"))
            {
                Spells.Q.Cast(target);
            }
        }

    }
}
