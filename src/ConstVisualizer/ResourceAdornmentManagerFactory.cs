﻿// <copyright file="ResourceAdornmentManagerFactory.cs" company="Matt Lacey">
// Copyright (c) Matt Lacey. All rights reserved.
// </copyright>

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace ConstVisualizer
{
    /// <summary>
    /// Establishes an <see cref="IAdornmentLayer"/> to place the adornment on and exports the <see cref="IWpfTextViewCreationListener"/>
    /// that instantiates the adornment on the event of a <see cref="IWpfTextView"/>'s creation.
    /// </summary>
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("CSharp")]
    [ContentType("Basic")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class ResourceAdornmentManagerFactory : IWpfTextViewCreationListener
    {
        /// <summary>
        /// Defines the adornment layer for the adornment.
        /// </summary>
        [Export(typeof(AdornmentLayerDefinition))]
        [Name("ConstCommentLayer")]
        [Order(After = PredefinedAdornmentLayers.Selection, Before = PredefinedAdornmentLayers.Text)]
        [TextViewRole(PredefinedTextViewRoles.Document)]
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
        public AdornmentLayerDefinition editorAdornmentLayer = null;
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore SA1401 // Fields should be private

        /// <summary>
        /// Instantiates a ResourceAdornment manager when a textView is created.
        /// </summary>
        /// <param name="textView">The <see cref="IWpfTextView"/> upon which the adornment should be placed.</param>
        public void TextViewCreated(IWpfTextView textView)
        {
            textView.Properties.GetOrCreateSingletonProperty<ResourceAdornmentManager>(() => new ResourceAdornmentManager(textView));
        }
    }
}
