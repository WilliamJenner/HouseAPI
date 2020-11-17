using System.Collections.Generic;
using House.DAL.DataTransferObjects;
using House.HLL.UniEvent.Models;
using Newtonsoft.Json;
using RestSharp;

namespace House.HLL.UniEvent.UniJson
{
    public static class UniJsonSerializer
    {
        public static IEnumerable<NewUniEvent> Serialize(IRestResponse result)
        {
            var deserialize = JsonConvert.DeserializeObject<RootJson>(result.Content);
            return deserialize.ToUniEvent();
        }

        private static IEnumerable<NewUniEvent> ToUniEvent(this RootJson json)
        {
            return json.Events.Select(x => new NewUniEvent
            {
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                EventType = x.ModuleTypeName.ToUniEventType(),
                Unit = x.ModuleName.ToUniUnit(),
                EventLeader = x.LecturerNames
            });
        }

        private static int ToUniEventType(this string moduleTypeName)
        {
            switch (moduleTypeName)
            {
                case "Lecture":
                    return (int)UniEventType.Lecture;
                case "LAB":
                    return (int)UniEventType.Lab;
                case "Seminar":
                    return (int)UniEventType.Seminar;
                default:
                    return (int)UniEventType.Unknown;
            }
        }

        private static int ToUniUnit(this string moduleName)
        {
            switch (moduleName)
            {
                case "ADVANCED DEVELOPMENT (Online)":
                    return (int)Unit.AdvancedDevelopment;
                case "INDIVIDUAL PROJECT":
                case "INDIVIDUAL PROJECT (Online)":
                    return (int)Unit.IndividualProject;
                case "Seminar":
                    return (int)Unit.MachineIntelligence;
                case "SOFTWARE QUALITY AND TESTING (Online)":
                case "SOFTWARE QUALITY AND TESTING (Online), SOFTWARE QUALITY AND TESTING (Online), SOFTWARE QUALITY AND TESTING (Online), SOFTWARE QUALITY AND TESTING (Online)":
                    return (int)Unit.SoftwareQualityAndTesting;
                case "UBIQUITOUS COMPUTING (Online)":
                case "UBIQUITOUS COMPUTING (Online), UBIQUITOUS COMPUTING (Online), UBIQUITOUS COMPUTING (Online)":
                    return (int)Unit.UbiquitousComputing;
                default:
                    return (int)UniEventType.Unknown;
            }
        }
    }
}
