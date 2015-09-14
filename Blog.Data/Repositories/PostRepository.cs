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
        public List<PostDto> GetAllFull()
        {
            using (var Context = new BlogContext())
            {
                var query = Context.Post.ToList();

                var PostDtoList = new List<PostDto>();

                foreach (Post p in query)
                {
                    var TagList = new List<Tag>();

                    foreach (Tag t in p.Tags)
                    {
                        TagList.Add(
                            new Tag()
                            {
                                Id = t.Id,
                                Descricao = t.Descricao
                            }
                        );
                    }

                    PostDtoList.Add(
                        new PostDto()
                        {
                            Id = p.Id,
                            Titulo = p.Titulo,
                            Corpo = p.Corpo,
                            DataCriacao = p.DataCriacao,
                            UsarioId = p.UsuarioId,
                            UsuarioLogin = p.Usuario.Login,
                            Tags = TagList
                        }
                    );
                }

                return PostDtoList;

            }
        }

        // Método que insere o novo post na base juntamente com sua coleção de tags.
        public void InsertWithTags(Post post)
        {
            using (var Context = new BlogContext())
            {
                var ListTag = new List<Tag>();
                
                foreach (Tag t in post.Tags)
                {
                    ListTag.Add(Context.Tag.FirstOrDefault(tag => tag.Id == t.Id));
                };

                var NewPost = new Post
                {
                    Titulo = post.Titulo,
                    Corpo = post.Corpo,
                    DataCriacao = DateTime.Now,
                    UsuarioId = post.UsuarioId,
                    Tags = ListTag
                };

                Context.Entry(NewPost).State = EntityState.Added;
                Context.SaveChanges();
            }
        }
    }
}
