using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;

namespace dotnet_structuring.ViewModel
{
    public class GeneralData
    {
        public ProjectTypes Type { get; set; } = ProjectTypes.New;
        public string FolderPath { get; set; } = String.Empty;
        public string ProjectName { get; set; } = "New Project";
        public IEnumerable<Template> Templates { get; set; } = InitializeTemplates.Templates;
        public Template STemplate { get; set; } = InitializeTemplates.Templates[0];
    }

    public enum ProjectTypes
    {
        New,
        Existing
    }
}