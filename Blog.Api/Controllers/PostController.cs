using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Blog.Api.Models;
using Blog.Data.Entities;
using Blog.Data.Repositories;
using Blog.Data.Dto;
using System.Net.Http;

namespace Blog.Api.Controllers
{
    [Authorize]
    [RoutePrefix("Blog/Post")]
    public class PostController : ApiController
    {
        [Route("GetAll"), HttpGet, AllowAnonymous]
        public ICollection<PostModelGetAllPosts> GetAllPosts()
        {
            try
            {
                var PostRepository = new PostRepository();

                var PostModelGetList = new List<PostModelGetAllPosts>();

                foreach (PostDto p in PostRepository.GetAllPosts())
                {
                    PostModelGetList.Add(
                           new PostModelGetAllPosts()
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Content = p.Content,
                               CreationDate = p.CreationDate,
                               UserId = p.UserId,
                               UserLogin = p.UserLogin,
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

        [Route("Insert"), HttpPost]
        public HttpResponseMessage Insert(PostModelInsert model)
        {
            try
            {
                if (ModelState.IsValid && model != null)
                {
                    var Post = new Post
                    {
                        Title = model.Title,
                        Content = model.Content,
                        UserId = model.UserId,
                        Tags = model.Tags
                    };

                    var PostRepository = new PostRepository();

                    PostRepository.InsertPost(Post);

                    return Request.CreateResponse(HttpStatusCode.Created, "Post inserido com sucesso.");
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

        [Route("Delete"), HttpGet]
        public HttpResponseMessage Delete(int postId)
        {
            try
            {
                var PostRepository = new PostRepository();

                PostRepository.DeletePost(postId);

                return Request.CreateResponse(HttpStatusCode.OK, "Post excluído com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Erro " + e.Message);
            }
        }
    }
}
