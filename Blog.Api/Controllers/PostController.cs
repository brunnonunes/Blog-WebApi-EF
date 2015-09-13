using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Services.Description;
using Blog.Api.Models;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.Dto;
using System.Net.Http;

namespace Blog.Api.Controllers
{
    [RoutePrefix("Blog/Post")]
    public class PostController : ApiController
    {
        [Route("GetAllFull")]
        public ICollection<PostModelGet> GetAllFull()
        {
            try
            {
                var PostRepository = new PostRepository();

                var PostModelGetList = new List<PostModelGet>();

                foreach (PostDto p in PostRepository.GetAllFull())
                {
                    PostModelGetList.Add(
                           new PostModelGet()
                           {
                               Id = p.Id,
                               Titulo = p.Titulo,
                               Corpo = p.Corpo,
                               DataCriacao = p.DataCriacao,
                               UsarioId = p.UsarioId,
                               UsuarioLogin = p.UsuarioLogin,
                               Tags = p.Tags
                           }
                        );
                }

                return PostModelGetList;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public HttpResponseMessage Insert(PostModelInsert model)
        {
            try
            {
                if (ModelState.IsValid && model != null)
                {
                    //var TagList = new List<Tag>();

                    //var NovaTag = new Tag
                    //{
                    //    Descricao = "Beleza"
                    //};


                    //var TagList = new List<Tag>();

                    //var NovaTag = new Tag
                    //{
                    //    Id = 1
                    //};

                    //TagList.Add(NovaTag);                


                    var Post = new Post();
                                        
                    Post.Titulo = model.Titulo;
                    Post.Corpo = model.Corpo;
                    Post.DataCriacao = model.DataCriacao;
                    Post.UsuarioId = model.UsuarioId;
                    //Post.Tags = TagList;

                    var PostRepository = new PostRepository();

                    PostRepository.Insert(Post);                    

                    return Request.CreateResponse(HttpStatusCode.OK, "Post inserido com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Erro, preenchimento incorreto.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Erro " + e.Message);
            }
        }

    }
}
