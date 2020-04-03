do
language plpgsql
$$
    declare
        new_blog_entry_id  INT;
        blog_entry_title   text;
        blog_entry_titles  text[] := Array [
            'Getting Started with .NET Core,.NET Core',
            'Advanced .NET Core Configuration,.NET Core',
            'Getting started with .NET Core CLI,.NET Core',
            'Advanced .NET Core CLI,.NET Core',

            'Getting Started with EF Core,EF Core',
            'Advanced EF Core,EF Core',
            'Getting started with EF Core CLI,EF Core',
            'Advanced EF Core CLI,EF Core',

            'Getting Started with ASP.NET Core,ASP.NET Core',
            'Advanced ASP.NET Core,ASP.NET Core',
            'Getting started with ASP.NET Core CLI,ASP.NET Core',
            'Advanced ASP.NET Core CLI,ASP.NET Core',

            'Getting Started with Azure SQL,Azure SQL',
            'Advanced Azure SQL,Azure SQL',
            'Getting started with Azure SQL CLI,Azure SQL',
            'Advanced Azure SQL CLI,Azure SQL',

            'Getting Started with PostgreSQL for Azure,PostgreSQL for Azure',
            'Advanced PostgreSQL for Azure,PostgreSQL for Azure',
            'Getting started with PostgreSQL for Azure CLI,PostgreSQL for Azure',
            'Advanced PostgreSQL for Azure CLI,PostgreSQL for Azure'
            ];
        blog_post_comment  text;
        blog_post_comments text[] := Array ['I really enjoyed your blog_entry on ',
            'Do you have any more information on ',
            'My customer is looking for more information on ',
            'What other resources can I reference on ',
            'I am inexperienced with ',
            'I have read several other blog entry posts on '];
    begin

        /*loop through blogs*/
        foreach blog_entry_title in array blog_entry_titles
            loop
                raise notice 'Insert blog_entry: %', split_part(blog_entry_title, ',', 1);

                /*insert into blog_entry*/
                INSERT Into blog_entry (blog_entry_name, blog_entry_date)
                VALUES (split_part(blog_entry_title, ',', 1), current_timestamp)
                on conflict (blog_entry_name) do update set blog_entry_date = "excluded".blog_entry_date returning blog_entry_id into new_blog_entry_id;

                /*loop through posts*/

                foreach blog_post_comment in array blog_post_comments
                    loop
                        raise notice 'blog_post comment for category %',split_part(blog_entry_title, ',', 2);
                        /*insert into blog_post*/
                        insert into blog_post (blog_post_comment, blog_post_date, blog_entry_id)
                        VALUES (blog_post_comment || split_part(blog_entry_title, ',', 2), current_timestamp,
                                new_blog_entry_id);
                    end loop;

            end loop;
    end
$$;