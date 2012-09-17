﻿using Swank.Description;

namespace Tests.SpecificationBuilderModuleTests
{
    namespace ModuleDescriptions
    {
        namespace NoDescription
        {
            public class Module : ModuleDescription { }
            public class GetHandler { public object Execute(object request) { return null; } }
        }

        namespace Description
        {
            public class Module : ModuleDescription { public Module() { Name = "Some Module"; Comments = "Some comments."; } }
            public class GetHandler { public object Execute(object request) { return null; } }
        }

        namespace EmbeddedTextComments
        {
            public class Module : ModuleDescription { public Module() { Name = "Some Text Module"; } }
            public class GetHandler { public object Execute(object request) { return null; } }
        }

        namespace EmbeddedMarkdownComments
        {
            public class Module : ModuleDescription { public Module() { Name = "Some Markdown Module"; } }
            public class GetHandler { public object Execute(object request) { return null; } }
        }
    }

    namespace NoModules
    {
        public class GetHandler { public object Execute(object request) { return null; } }
    }

    namespace OneEmptyModule
    {
        public class EmptyModule : ModuleDescription { }
        public class GetHandler { public object Execute(object request) { return null; } }
    }

    namespace OneEmptyModuleAndOrphanedAction
    {
        public class GetHandler { public object Execute(object request) { return null; } }
        namespace SomeHandler
        {
            public class EmptyModule : ModuleDescription { }
            public class GetHandler { public object Execute(object request) { return null; } }
        }
    }

    namespace OneModuleAndOrphanedAction
    {
        public class GetHandler { public object Execute_Orphan(object request) { return null; } }
        namespace SomeHandler
        {
            public class EmptyModule : ModuleDescription { public EmptyModule() { Name = "Some Module"; } }
            public class GetHandler { public object Execute_InModule(object request) { return null; } }
        }
    }
}
