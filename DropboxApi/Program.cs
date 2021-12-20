using NUnit.Framework;
using RestSharp;
using System;
using FluentAssertions;
using DropboxApi;
using System.Threading;


namespace DropboxApi
{
    [TestFixture]
    public class DropboxApiTests 
    {
        private IRestClient client;
        private IRestResponse response;
        private IRestRequest request;
        private string token;

        [SetUp]
        public void RequestInit()
        {
            request = new RestRequest(Method.POST);
            token = "yaxOaoluGQMAAAAAAAAAAR2jGHgIMdM6C-B2mXcn2dWhPsKKJhRJtUeWreK4CloV";
        }

        [Test]
        public void UploadFile()
        {
            client = new RestClient("https://content.dropboxapi.com/2/files/upload")
            {
                Timeout = -1
                
            };
            client.AddDefaultHeader("Connection", "close");

            request.AddHeader("Dropbox-API-Arg", "{\"path\": \"/test2.txt\",\"mode\": \"overwrite\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request.AddHeader("Content-type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddParameter("test", ParameterType.RequestBody);
            response = client.Execute(request);
          
            response.IsSuccessful.Should().BeTrue();
            

        }

        [Test]
        public void GetMetadata()
        {
            
            client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata")  {
                Timeout = -1
            };
            client.AddDefaultHeader("Connection", "close");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddParameter("application/json", "{\"path\": \"/text.txt\",\"include_media_info\": false,\"include_deleted\": false,\"include_has_explicit_shared_members\": false}", ParameterType.RequestBody);
            response = client.Execute(request);  
            response.IsSuccessful.Should().BeTrue();
            

        }

        [Test]
        public void DeleteFile()
        {
            client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2")
            {
                Timeout = -1
            };
            client.AddDefaultHeader("Connection", "close");
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddParameter("application/json", "{\"path\": \"/test.txt\"\r\n}", ParameterType.RequestBody);
            response = client.Execute(request);
            
            response.IsSuccessful.Should().BeTrue();


        }
    }
}
