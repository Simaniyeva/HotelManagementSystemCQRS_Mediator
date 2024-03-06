namespace HotelAPI.Application.Features.Queries.CountryQueries.GetCountryById
{
    public class GetCountryByIdQueryRequest:IRequest<GetCountryByIdQueryResponse>
    {
        public int Id { get; set; }
        public bool getDeleted { get; set; }
        public string[] Includes { get; set; }
    }
}
