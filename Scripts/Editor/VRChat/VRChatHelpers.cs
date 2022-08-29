﻿using Pumkin.AvatarTools2;
using Pumkin.AvatarTools2.VRChat;
using Pumkin.Core.Helpers;
using System;
using UnityEditor;
using UnityEngine;

namespace Pumkin.AvatarTools2.VRChat
{
    public static class VRChatHelpers
    {
        public static void SetAvatarScale(GameObject avatar, float newScale, bool moveViewpoint, out Vector3 viewpointPos)
        {
            SetAvatarScale(avatar, Vector3Helpers.RoundVectorValues(new Vector3(newScale, newScale, newScale), 3), moveViewpoint, out viewpointPos);
        }

        public static void SetAvatarScale(GameObject avatar, Vector3 newScale, bool moveViewpoint, out Vector3 viewpointPos)
        {
            viewpointPos = default;
            var desc = avatar.GetComponent(VRChatTypes.VRC_AvatarDescriptor);
            if(desc == null)
            {
                avatar.transform.localScale = newScale;
                return;
            }

            SerializedObject serialDesc = new SerializedObject(desc);
            var viewProp = serialDesc.FindProperty("ViewPosition");

            Transform tempDummy = null;
            if(moveViewpoint)
            {
                tempDummy = new GameObject("_dummy").transform;
                try
                {
                    tempDummy.localPosition = viewProp.vector3Value + avatar.transform.position;
                    tempDummy.parent = avatar.transform;
                }
                catch(Exception e)
                {
                    PumkinTools.LogVerbose(e.Message);
                }
            }

            avatar.transform.localScale = newScale;

            if(moveViewpoint)
            {
                try
                {
                    viewpointPos = tempDummy.transform.position;
                    tempDummy.parent = null;
                    viewProp.vector3Value = Vector3Helpers.RoundVectorValues(tempDummy.position - avatar.transform.position, 3);
                }
                finally
                {
                    if(tempDummy != null)
                        UnityObjectHelpers.DestroyAppropriate(tempDummy.gameObject);
                }
            }

            serialDesc.ApplyModifiedProperties();
        }

        public static void SetAvatarViewpoint(GameObject avatar, Vector3 viewPosition)
        {
            if(avatar == null)
                return;

            var desc = avatar.GetComponent(VRChatTypes.VRC_AvatarDescriptor);
            if(desc == null)
                return;

            SerializedObject serialDesc = new SerializedObject(desc);
            SetAvatarViewpoint(serialDesc, viewPosition, avatar.transform.position);
        }

        public static void SetAvatarViewpoint(SerializedObject descriptor, Vector3 viewPosition, Vector3 avatarPositionOffset = default)
        {
            if(descriptor == null)
                return;

            var viewProp = descriptor.FindProperty("ViewPosition");

            descriptor.FindProperty("ViewPosition").vector3Value = Vector3Helpers.RoundVectorValues(viewPosition - avatarPositionOffset, 3);
            descriptor.ApplyModifiedProperties();
        }

        //public static void QuickSetViewpoint(GameObject avatar, float zDepth)
        //{
        //    var desc = avatar.GetComponent(VRChatTypes.VRC_AvatarDescriptor) ?? avatar.AddComponent(VRChatTypes.VRC_AvatarDescriptor);
        //    var anim = avatar.GetComponent<Animator>();

        //    desc.ViewPosition = GetViewpointAtEyeLevel(SelectedAvatar.GetComponent<Animator>());
        //    desc.ViewPosition.z = zDepth;

        //    if(anim.isHuman)
        //        Log(Strings.Log.settingQuickViewpoint, LogType.Log, desc.ViewPosition.ToString());
        //    else
        //        Log(Strings.Log.cantSetViewpointNonHumanoid, LogType.Warning, desc.ViewPosition.ToString());
        //}
    }
}