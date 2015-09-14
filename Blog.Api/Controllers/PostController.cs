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
        [Route("GetAll"), HttpGet]
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
                    var TagList = new List<Tag>();
                    var NovaTag = new Tag
                    {
                        Id = 2
                    };
                    TagList.Add(NovaTag);

                    var Post = new Post();

                    Post.Title = model.Title;
                    Post.Content = model.Content;
                    Post.UserId = model.UserId;
                    Post.Tags = TagList;

                    var PostRepository = new PostRepository();

                    PostRepository.InsertWithTags(Post);

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
