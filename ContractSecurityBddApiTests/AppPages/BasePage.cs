using ServiceStack;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Faker;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using System.IO;
using ContractSecurityBddApiTests.ApiObjects;

namespace ContractSecurityBddApiTests.AppPages
{
    public class BasePage
    {
        public static string url = GetJsonConfigurationValue("baseUrl");
        public JsonServiceClient tagClient = new JsonServiceClient(url);
        public Random random = new Random();

        public void AddHeaders()
        {
            tagClient.AddHeader("API-Key", "8xjj3Ho7aa50sMyTvi0IBwY1eyJjDqAf");
            tagClient.AddHeader("Authorization", "aWJyYWhpbXV5ZUBnbWFpbC5jb206V1dER0w2NDczQzg0TUQ0OQ==");
        }

        public List<string> GetListOfUniqueVulnerabilitieTags()
        {
            AddHeaders();
            var urlSuffix = "tags/traces";
            var tagResponse = tagClient.Get<VulnerabilityTags>(urlSuffix);

            var listOfTags = tagResponse.tags;
           
            return listOfTags;

        }

        public int GetNumberOfUniqueVulnerabilitieTags()
        {
            AddHeaders();
            var urlSuffix = "tags/traces";
            var tagResponse = tagClient.Get<VulnerabilityTags>(urlSuffix);

            var numberOfTags = tagResponse.tags.Count;

            Debug.WriteLine(numberOfTags);
            return numberOfTags;

        }

        //I assume we always have vulnerabilities in DB to get one, it will be wise to take this method into try catch block and if there is no data in DB and there is 
        // and exception then  would innsert some vulneribility data into DB
        // this check could be either here or in Hooks class before starting the tests
        public string GetARandomVulnerabilityId()
        {
            AddHeaders();
            var urlSuffix = "orgtraces/filter";
            var vulneribilityResponse = tagClient.Get<Vulnerabilities>(urlSuffix);

            var listOfVulnerabilities = vulneribilityResponse.traces;
            var numberOftraces = listOfVulnerabilities.Count;
            var indexOfLuckyVulneribilty = random.Next(0, numberOftraces - 1);

            Debug.WriteLine(listOfVulnerabilities[indexOfLuckyVulneribilty].instance_uuid);
            return listOfVulnerabilities[indexOfLuckyVulneribilty].instance_uuid;

        }

        public void TagRandomlyVulneribilities(int numberofVulneribilitiesToTag)
        {
            AddHeaders();
            var urlSuffix = "tags/traces";

            for (int i = 0; i < numberofVulneribilitiesToTag; i++)
            {
                var payload = new TagObject
                {
                    tags = new List<string> { "assignedTo" + Name.First() },
                    traces_id = new List<string> { GetARandomVulnerabilityId() },
                };

                tagClient.Put<object>(urlSuffix, payload);
            }

        }

        public void TagASpecificVulneribilityByName(string traceUuid)
        {
            AddHeaders();
            var urlSuffix = "tags/traces";
            
                var payload = new TagObject
                {
                    tags = new List<string> { "assignedTo" + Name.First() },
                    traces_id = new List<string> { traceUuid },
                };

                tagClient.Put<object>(urlSuffix, payload);         

        }

        public void TagASpecificVulneribilityByDate(string traceUuid)
        {
            AddHeaders();
            var urlSuffix = "tags/traces";

            var payload = new TagObject
            {
                tags = new List<string> { "assignedOn_" + DateTime.Today+48 },
                traces_id = new List<string> { traceUuid },
            };

            tagClient.Put<object>(urlSuffix, payload);

        }

        public List<string> GetTagsOnAVulnerability(string traceUuid)
        {
            AddHeaders();

            var urlSuffix = "tags/traces/trace/" + traceUuid;
            var tagResponse = tagClient.Get<VulnerabilityTags>(urlSuffix);

            var listOfTags = tagResponse.tags;
            var numberOftags = listOfTags.Count;
                       
            return listOfTags;

        }

        public int GetNumberOfTagsOnAVulnerability(string traceUuid)
        {
            AddHeaders();

            var urlSuffix = "tags/traces/trace/" + traceUuid;
            var tagResponse = tagClient.Get<VulnerabilityTags>(urlSuffix);

            var listOfTags = tagResponse.tags;
            var numberOftags = listOfTags.Count;

            return numberOftags;

        }

        public void RemoveTagFromAvulneribility(string traceUuid, string tagToDelete)
        {
            var url = "https://ce.contrastsecurity.com/Contrast/api/ng/e10cd1cf-4e59-4a9d-804e-cc8d21057699/tags/trace/" + traceUuid;
            var tagClient = new JsonServiceClient(url);
            AddHeaders();

            var payload = new TagObject
            {
                tag = tagToDelete
            };

            tagClient.DeleteAsync<object>(payload);
        }


        public static string GetJsonConfigurationValue(string key)
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppConfig.json").Build().GetSection(key).Value;
        }

    }
}
