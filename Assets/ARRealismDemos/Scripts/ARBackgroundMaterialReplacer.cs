//-----------------------------------------------------------------------
// <copyright file="ARBackgroundMaterialReplacer.cs" company="Google">
//
// Copyright 2020 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;

/// <summary>
/// Replaces the AR background material with the provided material.
/// </summary>
public class ARBackgroundMaterialReplacer : MonoBehaviour
{
    /// <summary>
    /// First person camera.
    /// </summary>
    public GameObject FirstPersonCamera;

    /// <summary>
    /// Replacement material for the background renderer.
    /// </summary>
    public Material ReplacementMaterial;

    private DemoARBackgroundRenderer m_BackgroundRenderer;

    /// <summary>
    /// Replaces the AR background material.
    /// </summary>
    private void ReplaceBackground()
    {
        if (ReplacementMaterial == null)
        {
            return;
        }

        if (FirstPersonCamera == null)
        {
            FirstPersonCamera = Camera.main.gameObject;
        }

        m_BackgroundRenderer = FirstPersonCamera.GetComponent<DemoARBackgroundRenderer>();

        if (m_BackgroundRenderer != null)
        {
            m_BackgroundRenderer.SwapBackgroundMaterial(ReplacementMaterial);
        }
    }

    /// <summary>
    /// Recovers the previous AR background material.
    /// </summary>
    private void UndoReplace()
    {
        if (m_BackgroundRenderer != null)
        {
            m_BackgroundRenderer.ResetBackgroundMaterial();
        }
    }

    private void OnDestroy()
    {
        UndoReplace();
    }

    private void Start()
    {
        ReplaceBackground();
    }
}
