﻿using NUnit.Framework;
using Should;
using Swank.Description;
using Tests.Description.EndpointSourceTests.Templates;

namespace Tests.Description.EndpointSourceTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void should_pull_description_from_method_attribute()
        {
            var action = Behaviors.CreateAction<TemplatePostHandler>("/templates", HttpVerbs.Post);
            var endpointSource = new EndpointSource();
            var description = endpointSource.GetDescription(action);
            description.Name.ShouldEqual("AddTemplate");
            description.Comments.ShouldEqual("This adds a the template yo.");
        }

        [Test]
        public void should_pull_description_from_handler_attribute()
        {
            var action = Behaviors.CreateAction<TemplateGetAllHandler>("/templates", HttpVerbs.Get);
            var endpointSource = new EndpointSource();
            var description = endpointSource.GetDescription(action);
            description.Name.ShouldEqual("GetTemplates");
            description.Comments.ShouldEqual("This gets all the templates yo.");
        }

        [Test]
        public void should_pull_description_from_embedded_resource_named_as_handler()
        {
            var action = Behaviors.CreateAction<TemplateGetHandler>("/templates/{Id}", HttpVerbs.Get);
            var endpointSource = new EndpointSource();
            var description = endpointSource.GetDescription(action);
            description.Name.ShouldBeNull();
            description.Comments.ShouldEqual("<b>This gets a template yo!</b>");
        }

        [Test]
        public void should_pull_description_from_embedded_resource_named_as_handler_and_method()
        {
            var action = Behaviors.CreateAction<TemplatePutHandler>("/templates/{Id}", HttpVerbs.Put);
            var endpointSource = new EndpointSource();
            var description = endpointSource.GetDescription(action);
            description.Name.ShouldBeNull();
            description.Comments.ShouldEqual("<p><strong>This updates a template yo!</strong></p>");
        }
    }
}