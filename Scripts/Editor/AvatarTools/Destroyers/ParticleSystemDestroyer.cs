﻿using Pumkin.AvatarTools.Base;
using Pumkin.Core;
using UnityEngine;

namespace Pumkin.AvatarTools.Destroyers
{
    [AutoLoad(DefaultIDs.Destroyers.ParticleSystem, ParentModuleID = DefaultIDs.Modules.Destroyer)]
    class ParticleSystemDestroyer : MultiComponentDestroyerBase
    {
        public override string[] ComponentTypeFullNamesAll { get; } = new string[]
        {
            typeof(ParticleSystem).FullName,
            typeof(ParticleSystemRenderer).FullName
        };
    }
}