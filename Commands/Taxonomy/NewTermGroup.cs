﻿using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Taxonomy
{
    [Cmdlet(VerbsCommon.New, "PnPTermGroup", SupportsShouldProcess = false)]
    [CmdletAlias("New-SPOTermGroup")]
    [CmdletHelp(@"Creates a taxonomy term group",
        Category = CmdletHelpCategory.Taxonomy,
        OutputType = typeof(TermGroup),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.taxonomy.termgroup.aspx")]
    [CmdletExample
        (Code = @"PS:> New-PnPTermGroup -GroupName ""Countries""",
        Remarks = @"Creates a new taxonomy term group named ""Countries""",
        SortOrder = 1)]
    public class NewTermGroup : SPOCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, 
            HelpMessage = "Name of the taxonomy term group to create.")]
        public string GroupName;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets,
            HelpMessage = "GUID to use for the term group; if not specified, or the empty GUID, a random GUID is generated and used.")]
        public Guid GroupId = default(Guid);

        [Parameter(Mandatory = false, 
            HelpMessage = "Description to use for the term group.")]
        public string Description;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets,
            HelpMessage = "Term store to check; if not specified the default term store is used.")]
        public string TermStoreName;

        protected override void ExecuteCmdlet()
        {
            var taxonomySession = TaxonomySession.GetTaxonomySession(ClientContext);
            // Get Term Store
            var termStore = default(TermStore);
            if (string.IsNullOrEmpty(TermStoreName))
            {
                termStore = taxonomySession.GetDefaultSiteCollectionTermStore();
            }
            else
            {
                termStore = taxonomySession.TermStores.GetByName(TermStoreName);
            }
            // Create Group
            var group = termStore.CreateTermGroup(GroupName, GroupId, Description);

            WriteObject(group);
        }

    }
}
