using Bondx.RabbitMQ.Extentions;
using Core.Repositories;
using Core.RequestModels;
using Core.ResponseModels;
using Core.Services;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer _producer;
        private readonly IDbRepository _dbRepository;
        private readonly string _baseUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;

        private readonly IPaySwaggerClient _client;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _backUrlSuccess;
        private readonly string _backUrlFail;
        private readonly string _georgianCardUrl;
        private readonly string _merchantId;
        private readonly string _lang;
        private readonly string _preAuth;

        public PaymentService(IConfiguration configuration,
                              IProducer producer,
                              IDbRepository dbRepository,

                              IPaySwaggerClient client,
                              IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _producer = producer;
            _dbRepository = dbRepository;
            _baseUrl = _configuration.GetValue<string>("iPayApiUrl");
            _clientId = _configuration.GetValue<string>("ClientId");
            _clientSecret = _configuration.GetValue<string>("ClientSecret");


            _client = client;
            _backUrlSuccess = _configuration.GetValue<string>("backUrlSuccess");
            _backUrlFail = _configuration.GetValue<string>("backUrlFail");
            _georgianCardUrl = _configuration.GetValue<string>("georgianCardUrl");
            _merchantId = _configuration.GetValue<string>("merchantId");
            _lang = _configuration.GetValue<string>("lang");
            _preAuth = _configuration.GetValue<string>("preAuth");
        }

        private async Task<TokenResponse> Auth()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var tokenRequest = new ClientCredentialsTokenRequest
            {
                Address = $"{_baseUrl}oauth2/token",
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                ClientCredentialStyle = ClientCredentialStyle.AuthorizationHeader,
                //GrantType = "client_credentials"
            };

            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(tokenRequest);

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.ErrorDescription);
            }

            return tokenResponse;
        }

        public async Task<IResponse<int>> Pay(AddPaymentRequest request)
        {
            var s = await Auth();
            var client = new RestClient($"{_georgianCardUrl}/payment/start.wsm?" +
                                     $"&lang={_lang}" +
                                     $"&page_id={request.PageId}" +
                                     $"&merch_id={_merchantId}" +
                                     $"&preauth={_preAuth}" +
                                     $"&back_url_s={_backUrlSuccess}{request.OrderId}" +
                                     $"&back_url_f={_backUrlFail}{request.OrderId}");

            var restRequest = new RestRequest(Method.GET);
            //restRequest.AddHeader("lang", request.Lang);
            //restRequest.AddHeader("page_id", request.PageId);
            //restRequest.AddHeader("merch_id", request.MerchantId);
            //restRequest.AddHeader("preauth", request.PreAuth);

            IRestResponse response = client.Execute(restRequest);
            return new Response<int>(response.IsSuccessful ? 1 : 0);
        }
        public async Task RegiisterCallBack(CallbackRequest request, EnumCollbackType collbackType)
        {
            switch (collbackType)
            {
                case EnumCollbackType.Payment:
                    await _dbRepository.AddPaymentCallBack(request);
                    break;
                case EnumCollbackType.Refund:
                    await _dbRepository.AddRefundCallBack(request);
                    break;
                default:
                    break;
            }
        }


        public Task<object> CheckPayment(object request)
        {
            throw new NotImplementedException();
        }
        public Task<object> RegisterPayment(object request)
        {
            throw new NotImplementedException();
        }
        public async Task PaymentSuceeded(string orderId)
        {
            await _producer.PushDynamicAsync(orderId);
        }
        public async Task PaymentFailed(string orderId)
        {
            await _producer.PushDynamicAsync(orderId);
        }

    }
}
