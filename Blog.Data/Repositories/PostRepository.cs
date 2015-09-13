using Blog.Data.DataSource;
using Blog.Data.Dto;
using Blog.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>
    {
        // Método que retorna as informações do Post.
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
    }
}
