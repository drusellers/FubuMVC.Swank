﻿using FubuMVC.Swank.Description;

namespace HelloWorld.Administration
{
    public class Module : ModuleDescription
    {
        public Module()
        {
            Name = "Administration";

            // We could have set the comments here but instead 
            // added them in a markdown document because they 
            // were a bit to complex.
            // Comments = "These are some lovely comments.";
        }    
    }
}