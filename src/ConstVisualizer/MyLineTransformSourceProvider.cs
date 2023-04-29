﻿// <copyright file="MyLineTransformSourceProvider.cs" company="Matt Lacey">
// Copyright (c) Matt Lacey. All rights reserved.
// </copyright>

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using Microsoft.VisualStudio.Utilities;

namespace ConstVisualizer
{
    [Export(typeof(ILineTransformSourceProvider))]
    [ContentType("CSharp")]
    [ContentType("Basic")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal class MyLineTransformSourceProvider : ILineTransformSourceProvider
    {
        ILineTransformSource ILineTransformSourceProvider.Create(IWpfTextView view)
        {
            ResourceAdornmentManager manager =
                view.Properties.GetOrCreateSingletonProperty(
                    () => new ResourceAdornmentManager(view));
            return new MyLineTransformSource(manager);
        }
    }
}
