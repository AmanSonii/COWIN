using COWIN_Registration.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COWIN_Registration.Api
{
    public class COWIN
    {
        private static RestClient client = new RestClient("https://cdn-api.co-vin.in/api");
        public static List<State> GetStates()
        {
          //  var client = new RestClient("https://cdn-api.co-vin.in/api");
            var request = new RestRequest("v2/admin/location/states");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<List<State>>(response.Content);
        }

        public static List<District> GetDistricts(string stateId)
        {
           // var client = new RestClient("https://cdn-api.co-vin.in/api");
            var request = new RestRequest($"/v2/admin/location/districts/{stateId}");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<List<District>>(response.Content);
        }

        public static List<Session> GetSessionByPin(string pin, string date)
        {
            // var client = new RestClient("https://cdn-api.co-vin.in/api");
            var request = new RestRequest($"/v2/appointment/sessions/public/findByPin?pincode={pin}&date={date}");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<List<Session>>(response.Content);
        }

        public static List<Session> GetSessionByDistrict(string districtId, string date)
        {
            // var client = new RestClient("https://cdn-api.co-vin.in/api");
            var request = new RestRequest($"/v2/appointment/sessions/public/findByDistrict?district_id={districtId}&date={date}");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<List<Session>>(response.Content);
        }

        public static List<Session> GetSessionForWeekByPin(string pin, string date)
        {
            // var client = new RestClient("https://cdn-api.co-vin.in/api");
            var request = new RestRequest($"/v2/appointment/sessions/public/calendarByPin?pincode={pin}&date={date}");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<List<Session>>(response.Content);
        }

        public static List<Session> GetSessionForWeekByDistrict(string districtId, string date)
        {
            // var client = new RestClient("https://cdn-api.co-vin.in/api");
            var request = new RestRequest($"/v2/appointment/sessions/public/calendarByDistrict?district_id ={districtId}&date={date}");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<List<Session>>(response.Content);
        }

        // it is draft
        public static List<Session> GetSessionForWeekByCenter(string districtId, string date)
        {
            // var client = new RestClient("https://cdn-api.co-vin.in/api");
            var request = new RestRequest($"/v2/appointment/sessions/public/calendarByDistrict?district_id ={districtId}&date={date}");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<List<Session>>(response.Content);
        }

        public static List<string> GetCertificateByBeneficiaryId(string beneficiaryId)
        {
            var request = new RestRequest($"/v2/appointment/sessions/public/calendarByDistrict?beneficiary_reference_id ={beneficiaryId}");
            var response = client.Get(request);
            var states = JArray.Parse(response.Content);
            return new List<string>() { "", "" };
        }

        //get all data for the vacination
        //public static List<string> GetTotalVaccinationData()
        //{
        //    var request = new RestRequest($"v1/reports/v2/getPublicReports?state_id=&district_id=&date=");
        //    var response = client.Get(request);
        //    var states = JArray.Parse(response.Content);
        //    return new List<string>() { "", "" };
        //}
    }
}

