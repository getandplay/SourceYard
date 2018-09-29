﻿using System.Collections.Generic;
using System.IO;
using dotnetCampus.SourceYard.Context;
using dotnetCampus.SourceYard.Utils;

namespace dotnetCampus.SourceYard.PackFlow
{
    internal class SourcePacker : IPackFlow
    {
        public void Pack(IPackingContext context)
        {
            var srcFolder = Path.Combine(context.PackingFolder, "src");
            FileSystem.IgnoreFileEndList = IgnoreFileEndList;
            FileSystem.IgnoreFolderList = IgnoreFolderList;
            FileSystem.CopyFolderContents(context.ProjectFolder, srcFolder, excludes: IgnoreFolderList);
        }

        private static IList<string> IgnoreFolderList { get; } = new List<string>()
        {
            ".vs", "bin", "obj", ".git", "x64", "x86"
        };

        private static IList<string> IgnoreFileEndList { get; } = new List<string>()
        {
            ".csproj.DotSettings", ".suo", ".user", ".sln.docstates", ".nupkg"
        };
    }
}