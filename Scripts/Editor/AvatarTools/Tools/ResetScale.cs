﻿using Pumkin.Core;
using Pumkin.Core.Helpers;
using Pumkin.Core.UI;
using UnityEditor;
using UnityEngine;

namespace Pumkin.AvatarTools2.Tools
{
    [AutoLoad(DefaultIDs.Tools.ResetScale, ParentModuleID = DefaultIDs.Modules.Tools_FixAvatar)]
    class ResetScale : ToolBase
    {
        public override UIDefinition UIDefs { get; set; }
            = new UIDefinition("Reset Scale", "Resets your selected object's scale to prefab");

        protected override bool Prepare(GameObject target)
        {
            if(!base.Prepare(target))
                return false;
            return PrefabHelpers.HasPrefab(target);
        }

        protected override bool DoAction(GameObject target)
        {
            var pref = PrefabUtility.GetCorrespondingObjectFromSource(target);
            if(!pref)
                return false;

            target.transform.localScale = pref.transform.localScale;
            return true;
        }
    }
}