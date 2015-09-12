using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Services.Description;
using Blog.Api.Models;
using Blog.Data.Entities;
using Blog.Data.Repositories;

namespace Blog.Api.Controllers
{
    [RoutePrefix("Blog/Post")]
    public class PostController : ApiController
    {

        [Route("GetAllPosts")]
        public ICollection<PostModelConsulta> GetValues()
        {
            try
            {
                var postRepository = new PostRepository();

                var PostModelConsultaList = new List<PostModelConsulta>();

                foreach (Post p in postRepository.GetAll())
                {

                    PostModelConsultaList.Add(
                           new PostModelConsulta()
                           {
                               Titulo = p.Titulo,
                               Corpo = p.Corpo,
                               DataCriacao = p.DataCriacao
                           }
                        );

                }

                return PostModelConsultaList;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden); 
            }
        }

    }
}
