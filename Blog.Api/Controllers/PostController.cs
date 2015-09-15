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
                    // Inserindo Tags...
                    var TagList = new List<Tag>();
                                        
                    //var NovaTag = new Tag
                    //{
                    //    Id = 2
                    //};
                    //TagList.Add(NovaTag);

                    var Post = new Post();

                    Post.Title = model.Title;
                    Post.Content = model.Content;
                    Post.UserId = model.UserId;
                    Post.Tags = TagList;

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
        public HttpResponseMessage Delete(int PostId)
        {
            try
            {
                var PostRepository = new PostRepository();                            

                PostRepository.DeletePost(PostId);

                return Request.CreateResponse(HttpStatusCode.OK, "Post excluído com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Erro " + e.Message);
            }
        }
    }
}
