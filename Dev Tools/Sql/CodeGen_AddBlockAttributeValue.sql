/* Code Generate 'AddBlockAttributeValue(...)' for migrations. 
This will list all of the block attribute values starting with most recently Inserted
Just pick the top few that you need for your migration depending
*/

begin

declare
@crlf varchar(2) = char(13) + char(10)


SELECT 
        '            // Attrib Value for Page/Block'+ isnull(p.Name, 'Page??') + '/' +  isnull(b.Name, 'Block??')+ ':'+ isnull(a.Name, '??') + ' (FieldType: ' + isnull(ft.Name, '??') + ')' +
        @crlf +
        '            AddBlockAttributeValue("'+     
        CONVERT(nvarchar(50), b.Guid)+ '","'+ 
        CONVERT(nvarchar(50), a.Guid)+ '","'+ 
        ISNULL(isnull(v.Value, ''),'')+ '");'+
        @crlf [CodeGen Recently Added Attribute Values],
        p.Name [Page.Name],
        b.Name [Block.Name],
        a.Name [Attribute.Name],
        v.Value [AttributeValue.Value],
        [aud].[DateTime] [Audit.DateTime]
  FROM [AttributeValue] [v]
  join [Attribute] [a] on [a].[Id] = [v].[AttributeId]
  left join [EntityType] [e] on [e].[Id] = [a].[EntityTypeId]
  join [FieldType] [ft] on [ft].[Id] = [a].[FieldTypeId]
  left join [Block] [b] on b.Id = [v].[EntityId]
  left outer join [Page] [p] on [b].[PageId] = [p].[Id]
  left outer join [Audit] [aud] on [a].[EntityTypeId] = [aud].[EntityTypeId] and [aud].[EntityId] = [v].[EntityId]
  where e.Name = 'Rock.Model.Block'
  and b.Guid is not null
order by [v].[Id] desc

end


/* Code Generate 'AddBlockAttributeValue(...)' for migrations. 
This will list all of the block attribute values starting with most recently Inserted/Updated by Rock (by looking at the Audit Log)
Just pick the top few that you need for your migration depending
*/

begin

SELECT 
        '            // Attrib Value for Page/Block'+ isnull(p.Name, 'Page??') + '/' +  isnull(b.Name, 'Block??')+ ':'+ isnull(a.Name, '??') + ' (FieldType: ' + isnull(ft.Name, '??') + ')' +
        @crlf +
        '            AddBlockAttributeValue("'+     
        CONVERT(nvarchar(50), b.Guid)+ '","'+ 
        CONVERT(nvarchar(50), a.Guid)+ '","'+ 
        ISNULL(isnull(v.Value, ''),'')+ '");'+
        @crlf [CodeGen Recently Updated Attribute Values within Rock],
        p.Name [Page.Name],
        b.Name [Block.Name],
        a.Name [Attribute.Name],
        v.Value [AttributeValue.Value],
        [aud].[DateTime] [Audit.DateTime]
  FROM [AttributeValue] [v]
  join [Attribute] [a] on [a].[Id] = [v].[AttributeId]
  left join [EntityType] [e] on [e].[Id] = [a].[EntityTypeId]
  join [FieldType] [ft] on [ft].[Id] = [a].[FieldTypeId]
  left join [Block] [b] on b.Id = [v].[EntityId]
  left outer join [Page] [p] on [b].[PageId] = [p].[Id]
  join [Audit] [aud] on [aud].[EntityTypeId] = 
   (select [Id] from [EntityType] where [Name] = 'Rock.Model.AttributeValue') 
    and [aud].[EntityId] = [v].[Id]
  where e.Name = 'Rock.Model.Block'
  and b.Guid is not null
order by [aud].[DateTime] desc

end