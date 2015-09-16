using Blog.Data.DataSource;
using Blog.Data.Dto;
using Blog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>
    {
        // Método que retorna todos os posts e suas respectivas tags.
        public List<PostDto> GetAllPosts()
        {
            using (var Context = new BlogContext())
            {
                var Query = Context.Post.ToList().OrderByDescending(p => p.CreationDate);

                var PostDtoList = new List<PostDto>();

                foreach (Post p in Query)
                {
                    var TagList = new List<Tag>();

                    foreach (Tag t in p.Tags)
                    {
                        TagList.Add(
                            new Tag()
                            {
                                Id = t.Id,
                                Description = t.Description
                            }
                        );
                    }

                    PostDtoList.Add(
                        new PostDto()
                        {
                            Id = p.Id,
                            Title = p.Title,
                            Content = p.Content,
                            CreationDate = p.CreationDate,
                            UserId = p.UserId,
                            UserLogin = p.User.Login,
                            Tags = TagList
                        }
                    );
                }

                return PostDtoList;

            }
        }

        // Método que insere o novo post na base juntamente com sua coleção de tags.
        public void InsertPost(Post post)
        {
            using (var Context = new BlogContext())
            {
                var ListTag = new List<Tag>();

                foreach (Tag t in post.Tags)
                {
                    ListTag.Add(Context.Tag.FirstOrDefault(tag => tag.Id == t.Id));
                };

                var Post = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    CreationDate = DateTime.Now,
                    UserId = post.UserId,
                    Tags = ListTag
                };

                Context.Entry(Post).State = EntityState.Added;
                Context.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            using (var Context = new BlogContext())
            {
                var Post = new Post();
                
                Post = Context.Post.Include("Tags").FirstOrDefault(p => p.Id == postId);
                
                Context.Entry(Post).State = EntityState.Deleted;
                Context.SaveChanges();               
            }
        }
    }
}
