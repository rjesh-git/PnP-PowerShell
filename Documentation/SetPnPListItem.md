#Set-PnPListItem
Updates a list item
##Syntax
```powershell
Set-PnPListItem -Identity <ListItemPipeBind>
                [-ContentType <ContentTypePipeBind>]
                [-Values <Hashtable>]
                [-Web <WebPipeBind>]
                -List <ListPipeBind>
```


##Returns
>[Microsoft.SharePoint.Client.ListItem](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.listitem.aspx)

##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
|ContentType|ContentTypePipeBind|False|Specify either the name, ID or an actual content type|
|Identity|ListItemPipeBind|True|The ID of the listitem, or actual ListItem object|
|List|ListPipeBind|True|The ID, Title or Url of the list.|
|Values|Hashtable|False|Use the internal names of the fields when specifying field names.

Single line of text: -Values @{"Title" = "Title New"}

Multiple lines of text: -Values @{"MultiText" = "New text\n\nMore text"}

Rich text: -Values @{"MultiText" = "<strong>New</strong> text"}

Choice: -Values @{"Choice" = "Value 1"}

Number: -Values @{"Number" = "10"}

Currency: -Values @{"Number" = "10"}

Currency: -Values @{"Currency" = "10"}

Date and Time: -Values @{"DateAndTime" = "03/10/2015 14:16"}

Lookup (id of lookup value): -Values @{"Lookup" = "2"}

Yes/No: -Values @{"YesNo" = "No"}

Person/Group (id of user/group in Site User Info List or email of the user, seperate multiple values with a comma): -Values @{"Person" = "user1@domain.com","21"}

Hyperlink or Picture: -Values @{"Hyperlink" = "https://github.com/OfficeDev/, OfficePnp"}|
|Web|WebPipeBind|False|The web to apply the command to. Omit this parameter to use the current web.|
##Examples

###Example 1
```powershell
Set-PnPListItem -List "Demo List" -Identity 1 -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```
Sets fields value in the list item with ID 1 in the "Demo List". It sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.

###Example 2
```powershell
Set-PnPListItem -List "Demo List" -Identity 1 -ContentType "Company" -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```
Sets fields value in the list item with ID 1 in the "Demo List". It sets the content type of the item to "Company" and it sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.

###Example 3
```powershell
Set-PnPListItem -List "Demo List" -Identity $item -Values @{"Title" = "Test Title"; "Category"="Test Category"}
```
Sets fields value in the list item which has been retrieved by for instance Get-PnPListItem. It sets the content type of the item to "Company" and it sets both the Title and Category fields with the specified values. Notice, use the internal names of fields.
