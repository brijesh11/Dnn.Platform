﻿
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information


using System.ComponentModel;
using System.Web.UI;

namespace DotNetNuke.Web.UI.WebControls
{
    [ParseChildren(true)]
    public class DnnFormTemplateItem : DnnFormItemBase
    {
        [Browsable(false)]
        [DefaultValue(null)]
        [Description("The Item Template.")]
        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(DnnFormEmptyTemplate))]
        public ITemplate ItemTemplate { get; set; }

        protected override void CreateControlHierarchy()
        {
            this.CssClass += " dnnFormItem";
            this.CssClass += (this.FormMode == DnnFormMode.Long) ? " dnnFormLong" : " dnnFormShort";

            var template = new DnnFormEmptyTemplate();
            this.ItemTemplate.InstantiateIn(template);
            this.Controls.Add(template);
        }
    }
}
