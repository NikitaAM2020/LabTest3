using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RESTTest.Model;
using System.Collections.Generic;
using System.Net;

namespace Lab_3

{

    [TestFixture]
    public class CompleteTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GET_WhenGetPostsWithId_ShouldBeSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking");
            RestRequest request = new RestRequest("", Method.Get);

            // act
            RestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void POST_WhenExecutePostModel_ShouldBeSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking");
            RestRequest request = new RestRequest("", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new PostsModel()
            {
                firstname = "Jim",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new BookingDates()
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });
            request.AddHeader("Accept", "application/json");
            // act
            RestResponse<PostsModel> response = client.Execute<PostsModel>(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }


       [Test]
        public void PUT_UpdateBookInformation_ShouldReturnSuccessResponse()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking/");
            RestRequest request = new RestRequest("3852", Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new PostsModel()
            {
                firstname = "Jim",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new BookingDates()
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });
            request.AddHeader("Accept", "application/json");

            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");

            // act
            var response = client.Execute<PostsModel>(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void DELETE_RemovePostsWithId_ShouldBeSuccessful()
        {
            // arrange
            RestClient client = new RestClient("https://restful-booker.herokuapp.com/booking/");
            RestRequest request = new RestRequest("3433", Method.Delete);

            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            
            // act
            RestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
        private RestClient client;
        private RestResponse<PostsModels> response;

        [Test]
        public void GET_WhenGetRequestWithMatchId_ShouldBeSuccessResponse()
        {
            RestClient client = new RestClient("https://ghibliapi.herokuapp.com/");
            RestRequest request = new RestRequest("films/dc2e6bd1-8156-4886-adff-b39e6043af0c", Method.Get);

            // act
            response = client.Execute<PostsModels>(request);

            // assert          
            Assert.That(response.Data.title, Is.EqualTo("Spirited Away"));
            Assert.That(response.Data.director, Is.EqualTo("Hayao Miyazaki"));
        }

        //[Test]
        //public void POST_WhenExecutePlayerRefreshPostRequest_ShouldBeSuccessResponse()
        //{
        //    // arrange
        //    RestClient client = new RestClient("https://api.opendota.com/api/players/");
        //    RestRequest request = new RestRequest("313629025/refresh", Method.Post);
        //    request.RequestFormat = DataFormat.Json;
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddHeader("Accept", "application/json");
        //    // act
        //    RestResponse response = client.Execute<PostsModel>(request);

        //    // assert
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        //}
    }
}