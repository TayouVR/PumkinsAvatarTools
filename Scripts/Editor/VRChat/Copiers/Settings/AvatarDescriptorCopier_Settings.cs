using Pumkin.AvatarTools2.Settings;
using Pumkin.AvatarTools2.VRChat.Copiers;
using Pumkin.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumkin.AvatarTools2.VRChat.Settings
{
    [CustomSettingsContainer(typeof(AvatarDescriptorCopier))]
    class AvatarDescriptorCopier_Settings : CopierSettingsContainerBase
    {
        public override bool OnlyAllowOneComponentOfType => true;

        public override PropertyDefinitions Properties { get; } = new PropertyDefinitions(new Dictionary<Type, PropertyGroup[]>
        {
            { VRChatTypes.VRC_AvatarDescriptor, new[]
                {
                    new PropertyGroup("Settings",
                        "Name",
                        "ScaleIPD",
                        "portraitCameraPositionOffset",
                        "portraitCameraRotationOffset",
                        "enableEyeLook",
                        "autoFootsteps",
                        "autoLocomotion"),
                    new PropertyGroup("Animations",
                        "Animations",
                        "customizeAnimationLayers",
                        "baseAnimationLayers",
                        "specialAnimationLayers",
                        "AnimationPreset"),
                    new PropertyGroup("Lipsync",
                        "lipSync",
                        "MouthOpenBlendShapeName",
                        "lipSyncJawBone",
                        "VisemeSkinnedMesh",
                        "lipSyncJawClosed",
                        "lipSyncJawOpen",
                        "VisemeBlendShapes"),
                    new PropertyGroup("Viewpoint",
                        "ViewPosition"),
                }
            },
            { VRChatTypes.PipelineManager, new[]
              {
                new PropertyGroup("Blueprint ID", "blueprintId")
              }
            }
        });
    }
}