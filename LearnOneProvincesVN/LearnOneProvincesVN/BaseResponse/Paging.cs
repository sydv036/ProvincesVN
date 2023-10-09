namespace LearnOneProvincesVN.Api.BaseResponse
{
    public class Paging<Entity> where Entity : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public Entity Data { get; set; }

        public Paging(int PageNumber, int PageSize, int TotalPage, Entity data)
        {
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
            this.TotalPage = TotalPage;
            this.Data = data;
        }
    }
}
