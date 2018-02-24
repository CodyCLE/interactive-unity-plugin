﻿/*
 * Mixer Unity SDK
 *
 * Copyright (c) Microsoft Corporation
 * All rights reserved.
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */
namespace Microsoft.Mixer
{
    /// Base class for Interactivity controls. All controls are created and 
    /// configured using Interactive Studio.
    /// </summary>
#if !WINDOWS_UWP
    [System.Serializable]
#endif
    public class InteractiveControl
    {
        /// <summary>
        /// Unique string identifier for this control
        /// </summary>
        public string ControlID
        {
            get;
            private set;
        }

        /// <summary>
        /// Indicates if control is enabled or disabled.
        /// </summary>
        public bool Disabled
        {
            get;
            private set;
        }

        /// <summary>
        /// The string of text that displays when a stream viewer (InteractiveParticipant) hovers over the control.
        /// </summary>
        public string HelpText
        {
            get;
            private set;
        }

        internal string ETag;
        internal string SceneID;

        /// <summary>
        /// Allow game client to disable a control.
        /// </summary>
        /// <param name="disabled">If "true", disables this control. If "false", enables this control</param>
        public void SetDisabled(bool disabled)
        {
            Disabled = disabled;
            InteractivityManager.SingletonInstance.SendSetButtonControlProperties(
                ControlID, 
                InteractivityManager.WS_MESSAGE_VALUE_DISABLED, 
                disabled,
                0,
                string.Empty,
                0);
        }

        internal InteractiveControl(string controlID, bool disabled, string helpText, string eTag, string sceneID)
        {
            ControlID = controlID;
            Disabled = disabled;
            HelpText = helpText;
            ETag = eTag;
            SceneID = sceneID;
        }
    }
}
