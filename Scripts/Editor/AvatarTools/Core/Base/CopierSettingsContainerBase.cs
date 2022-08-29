using Pumkin.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Pumkin.AvatarTools2.Settings
{
    [Serializable]
    public abstract class CopierSettingsContainerBase : SettingsContainerBase
    {
        /// <summary>
        /// Should we only allow one of this component type on each object?
        /// </summary>
        public virtual bool OnlyAllowOneComponentOfType => false;
        
        /// <summary>
        /// Should we remove all components of this type before copying? Leave null to hide toggle
        /// </summary>
        public bool? RemoveAllBeforeCopying = false;
        
        /// <summary>
        /// Should we create missing game objects? Leave null to hide toggle
        /// </summary>
        public bool? CreateGameObjects = true;


        public virtual PropertyDefinitions Properties { get; } = null;
        public bool HasProperties { get; private set; }

        bool drawExtraFields = false;
        bool hasFieldsInInspector = false;

        protected override void Initialize()
        {
            base.Initialize();
            HasProperties = Properties != null;
            drawExtraFields = RemoveAllBeforeCopying != null || CreateGameObjects != null;

            if(drawExtraFields)
            {
                // Check for fields that are drawn in the inspector for spacing
                foreach(var field in GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    if((field.IsPrivate && field.GetCustomAttribute<SerializeField>() == null) ||
                       (!field.IsPrivate && field.GetCustomAttribute<HideInInspector>() != null))
                        continue;

                    hasFieldsInInspector = true;
                    break;
                }
            }
        }

        public override void DrawUI()
        {
            base.DrawUI();
            if(HasProperties)
                DrawPropertyGroups();

            if(drawExtraFields)
            {
                if(HasProperties || hasFieldsInInspector)
                    EditorGUILayout.Space();
                
                if(CreateGameObjects != null)
                    CreateGameObjects = EditorGUILayout.ToggleLeft("Create Game Objects", (bool)CreateGameObjects);
                if(RemoveAllBeforeCopying != null)
                    RemoveAllBeforeCopying = EditorGUILayout.ToggleLeft("Remove All Before Copying", (bool)RemoveAllBeforeCopying);
            }
        }

        void DrawPropertyGroups()
        {
            int index = 0;
            int count = Properties.TypeProperties.Count;
            foreach(var type_propGroup in Properties.TypeProperties)
            {
                foreach(var group in type_propGroup.Value)
                {
                    EditorGUI.BeginChangeCheck();
                    bool enabled = EditorGUILayout.ToggleLeft(group.Name, group.Enabled);
                    if(EditorGUI.EndChangeCheck())
                    {
                        group.Enabled = enabled;
                    }
                }

                if(index < count)
                    EditorGUILayout.Space();
                index++;
            }
        }
    }
}