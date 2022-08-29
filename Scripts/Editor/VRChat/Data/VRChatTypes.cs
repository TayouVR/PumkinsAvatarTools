using Pumkin.Core.Helpers;
using System;

namespace Pumkin.AvatarTools2.VRChat
{
    /// <summary>
    /// Cached VRChat types. Null if not VRC SDK in project
    /// </summary>
    public static class VRChatTypes
    {        
        public static readonly Type VRC_AvatarDescriptor = TypeHelpers.GetTypeAnywhere("VRC.SDK3.Avatars.Components.VRCAvatarDescriptor");

        public static readonly Type PipelineManager = TypeHelpers.GetTypeAnywhere("VRC.Core.PipelineManager");
        public static readonly Type VRC_AvatarDescriptor_LipSyncStyle = TypeHelpers.GetTypeAnywhere("VRC.SDKBase.VRC_AvatarDescriptor+LipSyncStyle");
        public static readonly Type VRC_AvatarDescriptor_Viseme = TypeHelpers.GetTypeAnywhere("VRC.SDKBase.VRC_AvatarDescriptor+Viseme");
        public static readonly Type VRC_SpacialAudioSource = TypeHelpers.GetTypeAnywhere("VRC.SDKBase.VRC_SpatialAudioSource");
        public static readonly Type ONSPAudioSource = TypeHelpers.GetTypeAnywhere("ONSPAudioSource");
    }
}
