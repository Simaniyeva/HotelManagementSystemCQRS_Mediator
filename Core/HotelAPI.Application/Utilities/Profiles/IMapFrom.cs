namespace HotelAPI.Application.Utilities.Profiles
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
    }
}
