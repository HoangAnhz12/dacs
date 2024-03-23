namespace webTimPhong.Helpers
{
    public static class Constantmap
    {
        // neu ko tim thay gia tri lat/lng thi default la dia chi cua truong
        public const decimal DEFAULT_LATITUDE = 10.8537669m;
        public const decimal DEFAULT_LONGTITUDE = 106.7807777m;

        public static readonly string GOOGLE_MAP_MARKER_API =
            "https://maps.googleapis.com/maps/api/js?key=AIzaSyBA3KXzYW685fcx3GFkyENrkzd0PU45hDk&libraries=places&language=vi&callback=initMap";
    }
}
