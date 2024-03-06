namespace HotelAPI.Application.Utilities.Profiles
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
    }
}
