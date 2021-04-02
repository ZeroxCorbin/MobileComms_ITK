#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."

namespace MobileComms_ITK.REST
{
    using MobileComms_ITK.JSON.Types;

    using System = global::System;

    public partial class Client
    {
        private string _baseUrl = "";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public Client(string baseUrl, System.Net.Http.HttpClient httpClient)
        {
            BaseUrl = baseUrl;
            _httpClient = httpClient;
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

        private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);





        /// <summary>Create waitTaskCancel</summary>
        /// <returns>waitTaskCancel created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> WaitTaskCancel_POST_Async(WaitTaskCancelQuery body)
        {
            return WaitTaskCancel_POST_Async(body, System.Threading.CancellationToken.None);
        }
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create waitTaskCancel</summary>
        /// <returns>waitTaskCancel created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> WaitTaskCancel_POST_Async(WaitTaskCancelQuery body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/WaitTaskCancel");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }
        /// <summary>Get WaitTaskState by Robot Name</summary>
        /// <param name="robot">Robot Name</param>
        /// <returns>Return WaitTaskState</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<WaitTaskStateQuery> WaitTaskState_GET_Async(string robot)
        {
            return WaitTaskState_GET_Async(robot, System.Threading.CancellationToken.None);
        }
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get WaitTaskState by Robot Name</summary>
        /// <param name="robot">Robot Name</param>
        /// <returns>Return WaitTaskState</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<WaitTaskStateQuery> WaitTaskState_GET_Async(string robot, System.Threading.CancellationToken cancellationToken)
        {
            if(robot == null)
                throw new System.ArgumentNullException("robot");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/WaitTaskState/{robot}");
            urlBuilder_.Replace("{robot}", System.Uri.EscapeDataString(ConvertToString(robot, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<WaitTaskStateQuery>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("WaitTaskState Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }


        /// <summary>Get a list of DataStoreItem entities filter by GroupName</summary>
        /// <param name="groupName">GroupName</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_GROUPNAME_Async(string groupName)
        {
            return DataStoreItem_FILTER_BY_GROUPNAME_Async(groupName, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreItem entities filter by GroupName</summary>
        /// <param name="groupName">GroupName</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_GROUPNAME_Async(string groupName, System.Threading.CancellationToken cancellationToken)
        {
            if(groupName == null)
                throw new System.ArgumentNullException("groupName");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/ByGroupName/{GroupName}");
            urlBuilder_.Replace("{GroupName}", System.Uri.EscapeDataString(ConvertToString(groupName, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreItem>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of DataStoreItem entities filter by Type</summary>
        /// <param name="type">Type</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_TYPE_Async(string type)
        {
            return DataStoreItem_FILTER_BY_TYPE_Async(type, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreItem entities filter by Type</summary>
        /// <param name="type">Type</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_TYPE_Async(string type, System.Threading.CancellationToken cancellationToken)
        {
            if(type == null)
                throw new System.ArgumentNullException("type");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/ByType/{Type}");
            urlBuilder_.Replace("{Type}", System.Uri.EscapeDataString(ConvertToString(type, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreItem>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of DataStoreItem entities filter by ItemName</summary>
        /// <param name="itemName">ItemName</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_ITEMNAME_Async(string itemName)
        {
            return DataStoreItem_FILTER_BY_ITEMNAME_Async(itemName, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreItem entities filter by ItemName</summary>
        /// <param name="itemName">ItemName</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_ITEMNAME_Async(string itemName, System.Threading.CancellationToken cancellationToken)
        {
            if(itemName == null)
                throw new System.ArgumentNullException("itemName");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/ByItemName/{ItemName}");
            urlBuilder_.Replace("{ItemName}", System.Uri.EscapeDataString(ConvertToString(itemName, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreItem>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of DataStoreItem entities filter by Category</summary>
        /// <param name="category">Category</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_CATEGORY_Async(string category)
        {
            return DataStoreItem_FILTER_BY_CATEGORY_Async(category, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreItem entities filter by Category</summary>
        /// <param name="category">Category</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_CATEGORY_Async(string category, System.Threading.CancellationToken cancellationToken)
        {
            if(category == null)
                throw new System.ArgumentNullException("category");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/ByCategory/{Category}");
            urlBuilder_.Replace("{Category}", System.Uri.EscapeDataString(ConvertToString(category, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreItem>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of DataStoreItem entities filter by Source</summary>
        /// <param name="source">Source</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_SOURCE_Async(string source)
        {
            return DataStoreItem_FILTER_BY_SOURCE_Async(source, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreItem entities filter by Source</summary>
        /// <param name="source">Source</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_SOURCE_Async(string source, System.Threading.CancellationToken cancellationToken)
        {
            if(source == null)
                throw new System.ArgumentNullException("source");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/BySource/{Source}");
            urlBuilder_.Replace("{Source}", System.Uri.EscapeDataString(ConvertToString(source, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreItem>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of DataStoreItem entities filter by DisplayName</summary>
        /// <param name="displayName">DisplayName</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_DISPLAYNAME_Async(string displayName)
        {
            return DataStoreItem_FILTER_BY_DISPLAYNAME_Async(displayName, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreItem entities filter by DisplayName</summary>
        /// <param name="displayName">DisplayName</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_FILTER_BY_DISPLAYNAME_Async(string displayName, System.Threading.CancellationToken cancellationToken)
        {
            if(displayName == null)
                throw new System.ArgumentNullException("displayName");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/ByDisplayName/{DisplayName}");
            urlBuilder_.Replace("{DisplayName}", System.Uri.EscapeDataString(ConvertToString(displayName, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreItem>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of DataStoreItem entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_POLL_Async(string sinceTime)
        {
            return DataStoreItem_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreItem entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of DataStoreItem entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreItem>> DataStoreItem_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreItem>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get DataStoreItem by ID</summary>
        /// <param name="id">DataStoreItem Id</param>
        /// <returns>Return DataStoreItem</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<DataStoreItem> DataStoreItem_GET_Async(string id)
        {
            return DataStoreItem_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get DataStoreItem by ID</summary>
        /// <param name="id">DataStoreItem Id</param>
        /// <returns>Return DataStoreItem</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<DataStoreItem> DataStoreItem_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreItem/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<DataStoreItem>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("DataStoreItem Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of DataStoreValue entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of DataStoreValue entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreValue>> DataStoreValue_POLL_Async(string sinceTime)
        {
            return DataStoreValue_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of DataStoreValue entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of DataStoreValue entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<DataStoreValue>> DataStoreValue_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreValue/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<DataStoreValue>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get the Latest DataStoreValue by Name</summary>
        /// <param name="name">DataStoreValue Name</param>
        /// <returns>Return DataStoreValue</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<DataStoreValue> DataStoreValue_Get_Async(string name)
        {
            return DataStoreValue_Get_Async(name, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get the Latest DataStoreValue by Name</summary>
        /// <param name="name">DataStoreValue Name</param>
        /// <returns>Return DataStoreValue</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<DataStoreValue> DataStoreValue_Get_Async(string name, System.Threading.CancellationToken cancellationToken)
        {
            if(name == null)
                throw new System.ArgumentNullException("name");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreValueLatest/{name}");
            urlBuilder_.Replace("{name}", System.Uri.EscapeDataString(ConvertToString(name, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<DataStoreValue>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("DataStoreValue Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }
        /// <summary>Get DataStoreValue by ID</summary>
        /// <param name="id">DataStoreValue Id</param>
        /// <returns>Return DataStoreValue</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<DataStoreValue> DataStoreValue_GET_Async(string id)
        {
            return DataStoreValue_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get DataStoreValue by ID</summary>
        /// <param name="id">DataStoreValue Id</param>
        /// <returns>Return DataStoreValue</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<DataStoreValue> DataStoreValue_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/DataStoreValue/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<DataStoreValue>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("DataStoreValue Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of Dropoff entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_JOBID_Async(string jobId)
        {
            return Dropoff_FILTER_BY_JOBID_Async(jobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Dropoff entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_JOBID_Async(string jobId, System.Threading.CancellationToken cancellationToken)
        {
            if(jobId == null)
                throw new System.ArgumentNullException("jobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff/ByJobId/{JobId}");
            urlBuilder_.Replace("{JobId}", System.Uri.EscapeDataString(ConvertToString(jobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Dropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Dropoff entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_STATUS_Async(string status)
        {
            return Dropoff_FILTER_BY_STATUS_Async(status, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Dropoff entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_STATUS_Async(string status, System.Threading.CancellationToken cancellationToken)
        {
            if(status == null)
                throw new System.ArgumentNullException("status");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff/ByStatus/{Status}");
            urlBuilder_.Replace("{Status}", System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Dropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Dropoff entities filter by Robot</summary>
        /// <param name="robot">Robot</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_ROBOT_Async(string robot)
        {
            return Dropoff_FILTER_BY_ROBOT_Async(robot, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Dropoff entities filter by Robot</summary>
        /// <param name="robot">Robot</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_ROBOT_Async(string robot, System.Threading.CancellationToken cancellationToken)
        {
            if(robot == null)
                throw new System.ArgumentNullException("robot");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff/ByRobot/{Robot}");
            urlBuilder_.Replace("{Robot}", System.Uri.EscapeDataString(ConvertToString(robot, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Dropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Dropoff entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId)
        {
            return Dropoff_FILTER_BY_ASSIGNEDJOBID_Async(assignedJobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Dropoff entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId, System.Threading.CancellationToken cancellationToken)
        {
            if(assignedJobId == null)
                throw new System.ArgumentNullException("assignedJobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff/ByAssignedJobId/{AssignedJobId}");
            urlBuilder_.Replace("{AssignedJobId}", System.Uri.EscapeDataString(ConvertToString(assignedJobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Dropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Delete Dropoff by ID</summary>
        /// <param name="id">Dropoff Id</param>
        /// <returns>Dropoff deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Dropoff> Dropoff_DELETE_Async(string id)
        {
            return Dropoff_DELETE_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete Dropoff by ID</summary>
        /// <param name="id">Dropoff Id</param>
        /// <returns>Dropoff deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Dropoff> Dropoff_DELETE_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<Dropoff>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Dropoff entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_POLL_Async(string sinceTime)
        {
            return Dropoff_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Dropoff entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Dropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Dropoff>> Dropoff_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Dropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get Dropoff by ID</summary>
        /// <param name="id">Dropoff Id</param>
        /// <returns>Return Dropoff</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Dropoff> Dropoff_GET_Async(string id)
        {
            return Dropoff_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get Dropoff by ID</summary>
        /// <param name="id">Dropoff Id</param>
        /// <returns>Return Dropoff</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Dropoff> Dropoff_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<Dropoff>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Dropoff Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create Dropoff</summary>
        /// <returns>Dropoff created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> Dropoff_POST_Async(Dropoff body)
        {
            return Dropoff_POST_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create Dropoff</summary>
        /// <returns>Dropoff created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> Dropoff_POST_Async(Dropoff body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Dropoff");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of Goal entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Goal entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Goal>> Goal_POLL_Async(string sinceTime)
        {
            return Goal_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Goal entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Goal entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Goal>> Goal_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Goal/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Goal>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get Goal by ID</summary>
        /// <param name="id">Goal Id</param>
        /// <returns>Return Goal</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Goal> Goal_GET_Async(string id)
        {
            return Goal_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get Goal by ID</summary>
        /// <param name="id">Goal Id</param>
        /// <returns>Return Goal</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Goal> Goal_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Goal/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<Goal>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Goal Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Delete JobCancel by ID</summary>
        /// <param name="id">JobCancel Id</param>
        /// <returns>JobCancel deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobCancel> JobCancel_DELETE_Async(string id)
        {
            return JobCancel_DELETE_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete JobCancel by ID</summary>
        /// <param name="id">JobCancel Id</param>
        /// <returns>JobCancel deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobCancel> JobCancel_DELETE_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobCancel/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobCancel>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobCancel entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobCancel entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobCancel>> JobCancel_POLL_Async(string sinceTime)
        {
            return JobCancel_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobCancel entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobCancel entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobCancel>> JobCancel_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobCancel/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobCancel>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get JobCancel by ID</summary>
        /// <param name="id">JobCancel Id</param>
        /// <returns>Return JobCancel</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobCancel> JobCancel_GET_Async(string id)
        {
            return JobCancel_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get JobCancel by ID</summary>
        /// <param name="id">JobCancel Id</param>
        /// <returns>Return JobCancel</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobCancel> JobCancel_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobCancel/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobCancel>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("JobCancel Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create JobCancel</summary>
        /// <returns>JobCancel created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> JobCancel_POST_Async(JobCancel body)
        {
            return JobCancel_POST_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create JobCancel</summary>
        /// <returns>JobCancel created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> JobCancel_POST_Async(JobCancel body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobCancel");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of JobHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of JobHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobHistory>> JobHistory_HISTORY_Async(string sinceTime, string namekey)
        {
            return JobHistory_HISTORY_Async(sinceTime, namekey, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of JobHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobHistory>> JobHistory_HISTORY_Async(string sinceTime, string namekey, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Job/History?");
            if(sinceTime != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if(namekey != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("namekey") + "=").Append(System.Uri.EscapeDataString(ConvertToString(namekey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobHistory>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of Job entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_FILTER_BY_JOBID_Async(string jobId)
        {
            return Job_FILTER_BY_JOBID_Async(jobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Job entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_FILTER_BY_JOBID_Async(string jobId, System.Threading.CancellationToken cancellationToken)
        {
            if(jobId == null)
                throw new System.ArgumentNullException("jobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Job/ByJobId/{JobId}");
            urlBuilder_.Replace("{JobId}", System.Uri.EscapeDataString(ConvertToString(jobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Job>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Job entities filter by LastAssignedRobot</summary>
        /// <param name="lastAssignedRobot">LastAssignedRobot</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_FILTER_BY_LASTASSIGNEDROBOT_Async(string lastAssignedRobot)
        {
            return Job_FILTER_BY_LASTASSIGNEDROBOT_Async(lastAssignedRobot, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Job entities filter by LastAssignedRobot</summary>
        /// <param name="lastAssignedRobot">LastAssignedRobot</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_FILTER_BY_LASTASSIGNEDROBOT_Async(string lastAssignedRobot, System.Threading.CancellationToken cancellationToken)
        {
            if(lastAssignedRobot == null)
                throw new System.ArgumentNullException("lastAssignedRobot");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Job/ByLastAssignedRobot/{LastAssignedRobot}");
            urlBuilder_.Replace("{LastAssignedRobot}", System.Uri.EscapeDataString(ConvertToString(lastAssignedRobot, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Job>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Job entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_FILTER_BY_STATUS_Async(Status status)
        {
            return Job_FILTER_BY_STATUS_Async(status, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Job entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_FILTER_BY_STATUS_Async(Status status, System.Threading.CancellationToken cancellationToken)
        {
            if(status == null)
                throw new System.ArgumentNullException("status");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Job/ByStatus/{Status}");
            urlBuilder_.Replace("{Status}", System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Job>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Job entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_POLL_Async(string sinceTime)
        {
            return Job_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Job entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Job entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Job>> Job_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Job/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Job>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get Job by ID</summary>
        /// <param name="id">Job Id</param>
        /// <returns>Return Job</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Job> Job_GET_Async(string id)
        {
            return Job_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get Job by ID</summary>
        /// <param name="id">Job Id</param>
        /// <returns>Return Job</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Job> Job_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Job/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<Job>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Job Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of JobRequestDetail entities filter by JobRequest</summary>
        /// <param name="jobRequest">JobRequest</param>
        /// <returns>Return List of JobRequestDetail entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequestDetail>> JobRequestDetail_FILTER_BY_JOBREQUEST_Async(string jobRequest)
        {
            return JobRequestDetail_FILTER_BY_JOBREQUEST_Async(jobRequest, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobRequestDetail entities filter by JobRequest</summary>
        /// <param name="jobRequest">JobRequest</param>
        /// <returns>Return List of JobRequestDetail entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequestDetail>> JobRequestDetail_FILTER_BY_JOBREQUEST_Async(string jobRequest, System.Threading.CancellationToken cancellationToken)
        {
            if(jobRequest == null)
                throw new System.ArgumentNullException("jobRequest");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequestDetail/ByJobRequest/{JobRequest}");
            urlBuilder_.Replace("{JobRequest}", System.Uri.EscapeDataString(ConvertToString(jobRequest, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobRequestDetail>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobRequestDetail entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobRequestDetail entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequestDetail>> JobRequestDetail_POLL_Async(string sinceTime)
        {
            return JobRequestDetail_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobRequestDetail entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobRequestDetail entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequestDetail>> JobRequestDetail_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequestDetail/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobRequestDetail>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get JobRequestDetail by ID</summary>
        /// <param name="id">JobRequestDetail Id</param>
        /// <returns>Return JobRequestDetail</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobRequestDetail> JobRequestDetail_GET_Async(string id)
        {
            return JobRequestDetail_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get JobRequestDetail by ID</summary>
        /// <param name="id">JobRequestDetail Id</param>
        /// <returns>Return JobRequestDetail</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobRequestDetail> JobRequestDetail_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequestDetail/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobRequestDetail>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("JobRequestDetail Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create JobRequestDetail</summary>
        /// <returns>JobRequestDetail created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> JobRequestDetail_POST_Async(JobRequestDetail body)
        {
            return JobRequestDetail_POST_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create JobRequestDetail</summary>
        /// <returns>JobRequestDetail created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> JobRequestDetail_POST_Async(JobRequestDetail body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequestDetail");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of JobRequest entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_FILTER_BY_JOBID_Async(string jobId)
        {
            return JobRequest_FILTER_BY_JOBID_Async(jobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobRequest entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_FILTER_BY_JOBID_Async(string jobId, System.Threading.CancellationToken cancellationToken)
        {
            if(jobId == null)
                throw new System.ArgumentNullException("jobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequest/ByJobId/{JobId}");
            urlBuilder_.Replace("{JobId}", System.Uri.EscapeDataString(ConvertToString(jobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobRequest>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobRequest entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_FILTER_BY_STATUS_Async(string status)
        {
            return JobRequest_FILTER_BY_STATUS_Async(status, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobRequest entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_FILTER_BY_STATUS_Async(string status, System.Threading.CancellationToken cancellationToken)
        {
            if(status == null)
                throw new System.ArgumentNullException("status");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequest/ByStatus/{Status}");
            urlBuilder_.Replace("{Status}", System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobRequest>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobRequest entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId)
        {
            return JobRequest_FILTER_BY_ASSIGNEDJOBID_Async(assignedJobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobRequest entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId, System.Threading.CancellationToken cancellationToken)
        {
            if(assignedJobId == null)
                throw new System.ArgumentNullException("assignedJobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequest/ByAssignedJobId/{AssignedJobId}");
            urlBuilder_.Replace("{AssignedJobId}", System.Uri.EscapeDataString(ConvertToString(assignedJobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobRequest>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Delete JobRequest by ID</summary>
        /// <param name="id">JobRequest Id</param>
        /// <returns>JobRequest deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobRequest> JobRequest_DELETE_Async(string id)
        {
            return JobRequest_DELETE_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete JobRequest by ID</summary>
        /// <param name="id">JobRequest Id</param>
        /// <returns>JobRequest deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobRequest> JobRequest_DELETE_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequest/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobRequest>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobRequest entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_POLL_Async(string sinceTime)
        {
            return JobRequest_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobRequest entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobRequest entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobRequest>> JobRequest_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequest/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobRequest>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get JobRequest by ID</summary>
        /// <param name="id">JobRequest Id</param>
        /// <returns>Return JobRequest</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobRequest> JobRequest_GET_Async(string id)
        {
            return JobRequest_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get JobRequest by ID</summary>
        /// <param name="id">JobRequest Id</param>
        /// <returns>Return JobRequest</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobRequest> JobRequest_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequest/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobRequest>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("JobRequest Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create JobRequest</summary>
        /// <returns>JobRequest created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> JobRequest_POST_Async(JobRequest body)
        {
            return JobRequest_POST_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create JobRequest</summary>
        /// <returns>JobRequest created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> JobRequest_POST_Async(JobRequest body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobRequest");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of JobSegmentModify entities filter by SegmentId</summary>
        /// <param name="segmentId">SegmentId</param>
        /// <returns>Return List of JobSegmentModify entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegmentModify>> JobSegmentModify_FILTER_BY_SEGMENTID_Async(string segmentId)
        {
            return JobSegmentModify_FILTER_BY_SEGMENTID_Async(segmentId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegmentModify entities filter by SegmentId</summary>
        /// <param name="segmentId">SegmentId</param>
        /// <returns>Return List of JobSegmentModify entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegmentModify>> JobSegmentModify_FILTER_BY_SEGMENTID_Async(string segmentId, System.Threading.CancellationToken cancellationToken)
        {
            if(segmentId == null)
                throw new System.ArgumentNullException("segmentId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegmentModify/BySegmentId/{SegmentId}");
            urlBuilder_.Replace("{SegmentId}", System.Uri.EscapeDataString(ConvertToString(segmentId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegmentModify>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Delete JobSegmentModify by ID</summary>
        /// <param name="id">JobSegmentModify Id</param>
        /// <returns>JobSegmentModify deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobSegmentModify> JobSegmentModify_DELETE_Async(string id)
        {
            return JobSegmentModify_DELETE_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete JobSegmentModify by ID</summary>
        /// <param name="id">JobSegmentModify Id</param>
        /// <returns>JobSegmentModify deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobSegmentModify> JobSegmentModify_DELETE_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegmentModify/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobSegmentModify>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobSegmentModify entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobSegmentModify entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegmentModify>> JobSegmentModify_POLL_Async(string sinceTime)
        {
            return JobSegmentModify_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegmentModify entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobSegmentModify entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegmentModify>> JobSegmentModify_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegmentModify/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegmentModify>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get JobSegmentModify by ID</summary>
        /// <param name="id">JobSegmentModify Id</param>
        /// <returns>Return JobSegmentModify</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobSegmentModify> JobSegmentModify_GET_Async(string id)
        {
            return JobSegmentModify_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get JobSegmentModify by ID</summary>
        /// <param name="id">JobSegmentModify Id</param>
        /// <returns>Return JobSegmentModify</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobSegmentModify> JobSegmentModify_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegmentModify/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobSegmentModify>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("JobSegmentModify Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create JobSegmentModify</summary>
        /// <returns>JobSegmentModify created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> JobSegmentModify_POST_Async(JobSegmentModify body)
        {
            return JobSegmentModify_POST_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create JobSegmentModify</summary>
        /// <returns>JobSegmentModify created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> JobSegmentModify_POST_Async(JobSegmentModify body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegmentModify");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of JobSegmentHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of JobSegmentHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegmentHistory>> JobSegmentHistory_HISTORY_Async(string sinceTime, string namekey)
        {
            return JobSegmentHistory_HISTORY_Async(sinceTime, namekey, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegmentHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of JobSegmentHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegmentHistory>> JobSegmentHistory_HISTORY_Async(string sinceTime, string namekey, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegment/History?");
            if(sinceTime != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if(namekey != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("namekey") + "=").Append(System.Uri.EscapeDataString(ConvertToString(namekey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegmentHistory>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of JobSegment entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_STATUS_Async(Status2 status)
        {
            return JobSegment_FILTER_BY_STATUS_Async(status, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegment entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_STATUS_Async(Status2 status, System.Threading.CancellationToken cancellationToken)
        {
            if(status == null)
                throw new System.ArgumentNullException("status");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegment/ByStatus/{Status}");
            urlBuilder_.Replace("{Status}", System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegment>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobSegment entities filter by Job</summary>
        /// <param name="job">Job</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_JOB_Async(string job)
        {
            return JobSegment_FILTER_BY_JOB_Async(job, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegment entities filter by Job</summary>
        /// <param name="job">Job</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_JOB_Async(string job, System.Threading.CancellationToken cancellationToken)
        {
            if(job == null)
                throw new System.ArgumentNullException("job");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegment/ByJob/{Job}");
            urlBuilder_.Replace("{Job}", System.Uri.EscapeDataString(ConvertToString(job, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegment>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobSegment entities filter by Robot</summary>
        /// <param name="robot">Robot</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_ROBOT_Async(string robot)
        {
            return JobSegment_FILTER_BY_ROBOT_Async(robot, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegment entities filter by Robot</summary>
        /// <param name="robot">Robot</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_ROBOT_Async(string robot, System.Threading.CancellationToken cancellationToken)
        {
            if(robot == null)
                throw new System.ArgumentNullException("robot");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegment/ByRobot/{Robot}");
            urlBuilder_.Replace("{Robot}", System.Uri.EscapeDataString(ConvertToString(robot, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegment>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobSegment entities filter by GoalName</summary>
        /// <param name="goalName">GoalName</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_GOALNAME_Async(string goalName)
        {
            return JobSegment_FILTER_BY_GOALNAME_Async(goalName, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegment entities filter by GoalName</summary>
        /// <param name="goalName">GoalName</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_FILTER_BY_GOALNAME_Async(string goalName, System.Threading.CancellationToken cancellationToken)
        {
            if(goalName == null)
                throw new System.ArgumentNullException("goalName");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegment/ByGoalName/{GoalName}");
            urlBuilder_.Replace("{GoalName}", System.Uri.EscapeDataString(ConvertToString(goalName, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegment>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of JobSegment entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_POLL_Async(string sinceTime)
        {
            return JobSegment_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of JobSegment entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of JobSegment entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<JobSegment>> JobSegment_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegment/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<JobSegment>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get JobSegment by ID</summary>
        /// <param name="id">JobSegment Id</param>
        /// <returns>Return JobSegment</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<JobSegment> JobSegment_GET_Async(string id)
        {
            return JobSegment_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get JobSegment by ID</summary>
        /// <param name="id">JobSegment Id</param>
        /// <returns>Return JobSegment</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<JobSegment> JobSegment_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/JobSegment/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<JobSegment>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("JobSegment Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of PickupDropoff entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_FILTER_BY_JOBID_Async(string jobId)
        {
            return PickupDropoff_FILTER_BY_JOBID_Async(jobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of PickupDropoff entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_FILTER_BY_JOBID_Async(string jobId, System.Threading.CancellationToken cancellationToken)
        {
            if(jobId == null)
                throw new System.ArgumentNullException("jobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/PickupDropoff/ByJobId/{JobId}");
            urlBuilder_.Replace("{JobId}", System.Uri.EscapeDataString(ConvertToString(jobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<PickupDropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of PickupDropoff entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_FILTER_BY_STATUS_Async(string status)
        {
            return PickupDropoff_FILTER_BY_STATUS_Async(status, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of PickupDropoff entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_FILTER_BY_STATUS_Async(string status, System.Threading.CancellationToken cancellationToken)
        {
            if(status == null)
                throw new System.ArgumentNullException("status");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/PickupDropoff/ByStatus/{Status}");
            urlBuilder_.Replace("{Status}", System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<PickupDropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of PickupDropoff entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId)
        {
            return PickupDropoff_FILTER_BY_ASSIGNEDJOBID_Async(assignedJobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of PickupDropoff entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId, System.Threading.CancellationToken cancellationToken)
        {
            if(assignedJobId == null)
                throw new System.ArgumentNullException("assignedJobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/PickupDropoff/ByAssignedJobId/{AssignedJobId}");
            urlBuilder_.Replace("{AssignedJobId}", System.Uri.EscapeDataString(ConvertToString(assignedJobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<PickupDropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Delete PickupDropoff by ID</summary>
        /// <param name="id">PickupDropoff Id</param>
        /// <returns>PickupDropoff deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PickupDropoff> PickupDropoff_DELETE_Async(string id)
        {
            return PickupDropoff_DELETE_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete PickupDropoff by ID</summary>
        /// <param name="id">PickupDropoff Id</param>
        /// <returns>PickupDropoff deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PickupDropoff> PickupDropoff_DELETE_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/PickupDropoff/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<PickupDropoff>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of PickupDropoff entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_POLL_Async(string sinceTime)
        {
            return PickupDropoff_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of PickupDropoff entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of PickupDropoff entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<PickupDropoff>> PickupDropoff_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/PickupDropoff/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<PickupDropoff>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get PickupDropoff by ID</summary>
        /// <param name="id">PickupDropoff Id</param>
        /// <returns>Return PickupDropoff</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PickupDropoff> PickupDropoff_GET_Async(string id)
        {
            return PickupDropoff_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get PickupDropoff by ID</summary>
        /// <param name="id">PickupDropoff Id</param>
        /// <returns>Return PickupDropoff</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PickupDropoff> PickupDropoff_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/PickupDropoff/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<PickupDropoff>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("PickupDropoff Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create PickupDropoff</summary>
        /// <returns>PickupDropoff created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> PickupDropoff_POST_Async(PickupDropoff body)
        {
            return PickupDropoff_POST_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create PickupDropoff</summary>
        /// <returns>PickupDropoff created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> PickupDropoff_POST_Async(PickupDropoff body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/PickupDropoff");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of Pickup entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_FILTER_BY_JOBID_Async(string jobId)
        {
            return Pickup_FILTER_BY_JOBID_Async(jobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Pickup entities filter by JobId</summary>
        /// <param name="jobId">JobId</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_FILTER_BY_JOBID_Async(string jobId, System.Threading.CancellationToken cancellationToken)
        {
            if(jobId == null)
                throw new System.ArgumentNullException("jobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Pickup/ByJobId/{JobId}");
            urlBuilder_.Replace("{JobId}", System.Uri.EscapeDataString(ConvertToString(jobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Pickup>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Pickup entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_FILTER_BY_STATUS_Async(string status)
        {
            return Pickup_FILTER_BY_STATUS_Async(status, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Pickup entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_FILTER_BY_STATUS_Async(string status, System.Threading.CancellationToken cancellationToken)
        {
            if(status == null)
                throw new System.ArgumentNullException("status");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Pickup/ByStatus/{Status}");
            urlBuilder_.Replace("{Status}", System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Pickup>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Pickup entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId)
        {
            return Pickup_FILTER_BY_ASSIGNEDJOBID_Async(assignedJobId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Pickup entities filter by AssignedJobId</summary>
        /// <param name="assignedJobId">AssignedJobId</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_FILTER_BY_ASSIGNEDJOBID_Async(string assignedJobId, System.Threading.CancellationToken cancellationToken)
        {
            if(assignedJobId == null)
                throw new System.ArgumentNullException("assignedJobId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Pickup/ByAssignedJobId/{AssignedJobId}");
            urlBuilder_.Replace("{AssignedJobId}", System.Uri.EscapeDataString(ConvertToString(assignedJobId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Pickup>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Delete Pickup by ID</summary>
        /// <param name="id">Pickup Id</param>
        /// <returns>Pickup deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Pickup> Pickup_DELETE_Async(string id)
        {
            return Pickup_DELETE_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete Pickup by ID</summary>
        /// <param name="id">Pickup Id</param>
        /// <returns>Pickup deleted</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Pickup> Pickup_DELETE_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Pickup/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<Pickup>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Pickup entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_POLL_Async(string sinceTime)
        {
            return Pickup_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Pickup entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Pickup entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Pickup>> Pickup_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Pickup/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Pickup>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get Pickup by ID</summary>
        /// <param name="id">Pickup Id</param>
        /// <returns>Return Pickup</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Pickup> Pickup_GET_Async(string id)
        {
            return Pickup_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get Pickup by ID</summary>
        /// <param name="id">Pickup Id</param>
        /// <returns>Return Pickup</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Pickup> Pickup_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Pickup/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<Pickup>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Pickup Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create Pickup</summary>
        /// <returns>Pickup created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> Pickup_POST_Async(Pickup body)
        {
            return Pickup_POST_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create Pickup</summary>
        /// <returns>Pickup created</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> Pickup_POST_Async(Pickup body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Pickup");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 201)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of RobotFaultHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of RobotFaultHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFaultHistory>> RobotFaultHistory_HISTORY_Async(string sinceTime, string namekey)
        {
            return RobotFaultHistory_HISTORY_Async(sinceTime, namekey, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of RobotFaultHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of RobotFaultHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFaultHistory>> RobotFaultHistory_HISTORY_Async(string sinceTime, string namekey, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RobotFault/History?");
            if(sinceTime != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if(namekey != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("namekey") + "=").Append(System.Uri.EscapeDataString(ConvertToString(namekey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<RobotFaultHistory>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of RobotFault entities filter by Robot</summary>
        /// <param name="robot">Robot</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_ROBOT_Async(string robot)
        {
            return RobotFault_FILTER_BY_ROBOT_Async(robot, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of RobotFault entities filter by Robot</summary>
        /// <param name="robot">Robot</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_ROBOT_Async(string robot, System.Threading.CancellationToken cancellationToken)
        {
            if(robot == null)
                throw new System.ArgumentNullException("robot");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RobotFault/ByRobot/{Robot}");
            urlBuilder_.Replace("{Robot}", System.Uri.EscapeDataString(ConvertToString(robot, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<RobotFault>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of RobotFault entities filter by Type</summary>
        /// <param name="type">Type</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_TYPE_Async(string type)
        {
            return RobotFault_FILTER_BY_TYPE_Async(type, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of RobotFault entities filter by Type</summary>
        /// <param name="type">Type</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_TYPE_Async(string type, System.Threading.CancellationToken cancellationToken)
        {
            if(type == null)
                throw new System.ArgumentNullException("type");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RobotFault/ByType/{Type}");
            urlBuilder_.Replace("{Type}", System.Uri.EscapeDataString(ConvertToString(type, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<RobotFault>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of RobotFault entities filter by Name</summary>
        /// <param name="name">Name</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_NAME_Async(string name)
        {
            return RobotFault_FILTER_BY_NAME_Async(name, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of RobotFault entities filter by Name</summary>
        /// <param name="name">Name</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_NAME_Async(string name, System.Threading.CancellationToken cancellationToken)
        {
            if(name == null)
                throw new System.ArgumentNullException("name");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RobotFault/ByName/{Name}");
            urlBuilder_.Replace("{Name}", System.Uri.EscapeDataString(ConvertToString(name, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<RobotFault>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of RobotFault entities filter by Active</summary>
        /// <param name="active">Active</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_ACTIVE_Async(string active)
        {
            return RobotFault_FILTER_BY_ACTIVE_Async(active, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of RobotFault entities filter by Active</summary>
        /// <param name="active">Active</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_FILTER_BY_ACTIVE_Async(string active, System.Threading.CancellationToken cancellationToken)
        {
            if(active == null)
                throw new System.ArgumentNullException("active");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RobotFault/ByActive/{Active}");
            urlBuilder_.Replace("{Active}", System.Uri.EscapeDataString(ConvertToString(active, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<RobotFault>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of RobotFault entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_POLL_Async(string sinceTime)
        {
            return RobotFault_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of RobotFault entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of RobotFault entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotFault>> RobotFault_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RobotFault/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<RobotFault>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get RobotFault by ID</summary>
        /// <param name="id">RobotFault Id</param>
        /// <returns>Return RobotFault</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RobotFault> RobotFault_GET_Async(string id)
        {
            return RobotFault_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get RobotFault by ID</summary>
        /// <param name="id">RobotFault Id</param>
        /// <returns>Return RobotFault</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RobotFault> RobotFault_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/RobotFault/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RobotFault>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("RobotFault Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of RobotHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of RobotHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotHistory>> RobotHistory_HISTORY_Async(string sinceTime, string namekey)
        {
            return RobotHistory_HISTORY_Async(sinceTime, namekey, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of RobotHistory entities</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <param name="namekey">Namekey of an Entity</param>
        /// <returns>Return List of RobotHistory entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<RobotHistory>> RobotHistory_HISTORY_Async(string sinceTime, string namekey, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Robot/History?");
            if(sinceTime != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if(namekey != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("namekey") + "=").Append(System.Uri.EscapeDataString(ConvertToString(namekey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<RobotHistory>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of Robot entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Robot entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Robot>> Robot_FILTER_BY_STATUS_Async(Status3 status)
        {
            return Robot_FILTER_BY_STATUS_Async(status, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Robot entities filter by Status</summary>
        /// <param name="status">Status</param>
        /// <returns>Return List of Robot entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Robot>> Robot_FILTER_BY_STATUS_Async(Status3 status, System.Threading.CancellationToken cancellationToken)
        {
            if(status == null)
                throw new System.ArgumentNullException("status");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Robot/ByStatus/{Status}");
            urlBuilder_.Replace("{Status}", System.Uri.EscapeDataString(ConvertToString(status, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Robot>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Robot entities filter by SubStatus</summary>
        /// <param name="subStatus">SubStatus</param>
        /// <returns>Return List of Robot entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Robot>> Robot_FILTER_BY_SUBSTATUS_Async(SubStatus subStatus)
        {
            return Robot_FILTER_BY_SUBSTATUS_Async(subStatus, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Robot entities filter by SubStatus</summary>
        /// <param name="subStatus">SubStatus</param>
        /// <returns>Return List of Robot entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Robot>> Robot_FILTER_BY_SUBSTATUS_Async(SubStatus subStatus, System.Threading.CancellationToken cancellationToken)
        {
            if(subStatus == null)
                throw new System.ArgumentNullException("subStatus");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Robot/BySubStatus/{SubStatus}");
            urlBuilder_.Replace("{SubStatus}", System.Uri.EscapeDataString(ConvertToString(subStatus, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Robot>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list of Robot entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Robot entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Robot>> Robot_POLL_Async(string sinceTime)
        {
            return Robot_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of Robot entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of Robot entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<Robot>> Robot_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Robot/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<Robot>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get Robot by ID</summary>
        /// <param name="id">Robot Id</param>
        /// <returns>Return Robot</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Robot> Robot_GET_Async(string id)
        {
            return Robot_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get Robot by ID</summary>
        /// <param name="id">Robot Id</param>
        /// <returns>Return Robot</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Robot> Robot_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/Robot/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<Robot>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Robot Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        /// <summary>Get a list of SubscriptionConfig entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of SubscriptionConfig entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<SubscriptionConfig>> SubscriptionConfig_POLL_Async(string sinceTime)
        {
            return SubscriptionConfig_POLL_Async(sinceTime, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of SubscriptionConfig entities updates since the given time</summary>
        /// <param name="sinceTime">Timestamp millis</param>
        /// <returns>Return List of SubscriptionConfig entities</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<SubscriptionConfig>> SubscriptionConfig_POLL_Async(string sinceTime, System.Threading.CancellationToken cancellationToken)
        {
            if(sinceTime == null)
                throw new System.ArgumentNullException("sinceTime");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/SubscriptionConfig/UpdatedSince?");
            urlBuilder_.Append(System.Uri.EscapeDataString("sinceTime") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sinceTime, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<System.Collections.Generic.ICollection<SubscriptionConfig>>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get SubscriptionConfig by ID</summary>
        /// <param name="id">SubscriptionConfig Id</param>
        /// <returns>Return SubscriptionConfig</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<SubscriptionConfig> SubscriptionConfig_GET_Async(string id)
        {
            return SubscriptionConfig_GET_Async(id, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get SubscriptionConfig by ID</summary>
        /// <param name="id">SubscriptionConfig Id</param>
        /// <returns>Return SubscriptionConfig</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<SubscriptionConfig> SubscriptionConfig_GET_Async(string id, System.Threading.CancellationToken cancellationToken)
        {
            if(id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/SubscriptionConfig/ByKey/{id}");
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<SubscriptionConfig>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("SubscriptionConfig Not Found", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Update SubscriptionConfig</summary>
        /// <returns>SubscriptionConfig updated</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<RestResponse> SubscriptionConfig_PUT_Async(SubscriptionConfig body)
        {
            return SubscriptionConfig_PUT_Async(body, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Update SubscriptionConfig</summary>
        /// <returns>SubscriptionConfig updated</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<RestResponse> SubscriptionConfig_PUT_Async(SubscriptionConfig body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/SubscriptionConfig");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using(var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json; charset=utf-8"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if(response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach(var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if(status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponse_Async<RestResponse>(response_, headers_).ConfigureAwait(false);
                            if(objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if(status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Bad Request", status_, responseText_, headers_, null);
                        }
                        else
                        if(status_ == 500)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Internal server error", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if(disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if(disposeClient_)
                    client_.Dispose();
            }
        }



        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponse_Async<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers)
        {
            if(response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if(ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch(Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using(var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using(var streamReader = new System.IO.StreamReader(responseStream))
                    using(var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                    {
                        var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch(Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if(value == null)
            {
                return null;
            }

            if(value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if(name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if(field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if(attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    return System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                }
            }
            else if(value is bool)
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if(value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if(value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return (result is null) ? string.Empty : result;
        }
    }

    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108