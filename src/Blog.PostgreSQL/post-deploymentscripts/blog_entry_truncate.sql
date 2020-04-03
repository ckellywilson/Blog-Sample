truncate table blog_entry cascade;
alter sequence blog_entry_blog_entry_id_seq RESTART WITH 1;
alter sequence blog_post_blog_post_id_seq restart with 1;