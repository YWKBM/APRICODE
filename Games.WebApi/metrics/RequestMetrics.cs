using App.Metrics;
using App.Metrics.Counter;

namespace Games.WebApi.metrics
{
    public static class RequestMetrics
    {
        public static CounterOptions RequestGetAllCounter => new CounterOptions
        {
            Context = "GetAll",
            Name = "User GetAll Request",
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions RequestGetAlFilteredlCounter => new CounterOptions
        {
            Context = "GetAllFiltered",
            Name = "User GetAllFiltered Request",
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions RequestGetByIdCounter => new CounterOptions
        {
            Context = "GetById",
            Name = "User GetById Request",
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions RequestCreateCounter => new CounterOptions
        {
            Context = "Create",
            Name = "User Create Request",
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions RequestUpdateCounter => new CounterOptions
        {
            Context = "Update",
            Name = "User Update Request",
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions RequestDeleteCounter => new CounterOptions
        {
            Context = "Delete",
            Name = "User Delete Request",
            MeasurementUnit = Unit.Calls
        };
    }
}
