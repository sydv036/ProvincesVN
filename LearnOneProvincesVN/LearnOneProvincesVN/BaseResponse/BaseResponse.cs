using System.Net;

namespace LearnOneProvincesVN.Api.BaseResponse
{
    public class BaseResponse<Entity> where Entity : class
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }

        public HttpStatusCode Error { get; set; }

        public Entity Contents { get; set; }

        public BaseResponse(HttpStatusCode httpStatusCode, string message, HttpStatusCode error, Entity contents)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
            this.Error = error;
            this.Contents = contents;
        }
    }
}
